// AdinmoStoreController.cs
// Unity IAP v5 integration with AdInMo IAPBoost support
//
// ADVANCED: Pre-Purchase Event Hook (for custom callback attachment)
//   // Option 1: Automatic mode (default) - event fires, purchase continues immediately
//   AdinmoStoreController.OnPrePurchase += (args) => {
//       Debug.Log($"About to purchase: {args.ProductId}");
//       AttachMyCustomCallbacks(args.ProductId);
//   };
//
//   // Option 2: Paused mode - wait for your explicit approval
//   AdinmoStoreController.PauseBeforePurchase = true;
//   AdinmoStoreController.OnPrePurchase += (args) => {
//       Debug.Log($"Purchase paused for: {args.ProductId}");
//       AttachMyCustomCallbacks(args.ProductId);
//       // Then continue when ready:
//       AdinmoStoreController.ContinuePurchase(args.ProductId);
//   };
//
#nullable enable
#if ADINMO_UNITY_STORE_V5
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

using UnityEngine.Purchasing;
using UnityEngine.Scripting;

namespace Adinmo
{
    /// <summary>
    /// Pre-purchase event metadata passed to OnPrePurchase subscribers
    /// </summary>
    public class PrePurchaseEventArgs
    {
        public string ProductId { get; internal set; } = "";
        public Product? Product { get; internal set; }
    }

    /// <summary>
    /// Main controller class that provides a unified interface for store operations, product management, and purchase handling.
    /// </summary>
    /// 
    [Preserve]
    public class AdinmoStoreController:StoreController 
    {
        public static AdinmoStoreController? Instance;

        /// <summary>
        /// Event fired immediately before initiating a purchase through Unity IAP.
        /// Subscribe to this to run custom logic (e.g., attach callbacks) before the purchase flow starts.
        /// </summary>
        public event Action<PrePurchaseEventArgs>? OnPrePurchase;

        /// <summary>
        /// When true, the SDK will wait for ContinuePurchase() before calling Unity IAP.
        /// Default: false (immediate purchase for backward compatibility)
        /// </summary>
        public bool PauseBeforePurchase { get; set; } = false;

        private Dictionary<string, string> _pendingPurchases = new Dictionary<string, string>();

        [Preserve]
        public AdinmoStoreController(string? storeName = null):base(storeName)
        {
            OnPurchaseConfirmed += PurchaseConfirmed;
            OnPurchaseFailed += PurchaseFailed;
            Instance = this;
           
        }
        [Preserve]
        ~AdinmoStoreController()
        {
            OnPurchaseConfirmed -= PurchaseConfirmed;
            OnPurchaseFailed -= PurchaseFailed;
            Instance = null;
        }
        [Preserve]
        void PurchaseConfirmed(Order order)
        {
            foreach (var cartItem in order.CartOrdered.Items())
            {
                var product = cartItem.Product;
                switch (order)
                {
                    case FailedOrder failedOrder:
                        AdinmoManager.Sender?.LogInfo("Failed to order " + product + ", " + failedOrder.FailureReason);
                        AdinmoManager.InAppPurchaseFailed(product.definition.id, product.metadata.isoCurrencyCode, (float)product.metadata.localizedPrice, failedOrder.FailureReason.ToString());
                        break;
                    case ConfirmedOrder:

                        AdinmoManager.Sender?.LogInfo("Purchase confirmed for " + product );
                        AdinmoManager.InAppPurchaseSuccess(product.definition.id, product.metadata.isoCurrencyCode, (float)product.metadata.localizedPrice, order.Info.TransactionID);
                        break;
                }
             }
        }
        [Preserve]
        void PurchaseFailed(FailedOrder failedOrder)
        {
            foreach (var cartItem in failedOrder.CartOrdered.Items())
            {
                var product = cartItem.Product;
                AdinmoManager.Sender?.LogInfo("Failed to order " + product + ", " + failedOrder.FailureReason);
                AdinmoManager.InAppPurchaseFailed(product.definition.id, product.metadata.isoCurrencyCode, (float)product.metadata.localizedPrice, failedOrder.FailureReason.ToString());
            }
        }
        [Preserve]
        public static InAppAlreadyPurchasedReply CheckAlreadyPurchased(string IAP_ID)
        {
            if (Instance != null)
            {
                foreach (var order in Instance.GetPurchases())
                {
                    foreach (var cartItem in order.CartOrdered.Items())
                    {
                        Product product = cartItem.Product;
                        if (product.definition.id == IAP_ID)
                        {
                            AdinmoManager.Sender?.LogInfo(product.definition.id + " already purchased");
                            return new InAppAlreadyPurchasedReply(true, (float)product.metadata.localizedPrice, product.metadata.isoCurrencyCode);
                        }
                    }
                }
            }
            return new InAppAlreadyPurchasedReply(false);
        }
        [Preserve]
        public static string? GetPrice(string item)
        {
            if (Instance != null)
            {
                foreach (var product in Instance.GetProducts())
                {
                    if (product.definition.id == item)
                    {
                        return product.metadata.localizedPriceString;
                    }
                }
            }
            return null;
        }
        [Preserve]
        public static void PurchaseItem(string item)
        {
            if(Instance == null)
            {
                AdinmoManager.Sender?.LogError("Cannot process purchase - AdinmoStoreController not initialized");
                return;
            }

            // Find the product
            Product? product = null;
            foreach (var p in Instance.GetProducts())
            {
                if (p.definition.id == item)
                {
                    product = p;
                    break;
                }
            }

            // Fire instance pre-purchase event for custom callback attachment
            try
            {
                Instance.OnPrePurchase?.Invoke(new PrePurchaseEventArgs 
                { 
                    ProductId = item, 
                    Product = product 
                });
            }
            catch (Exception ex)
            {
                AdinmoManager.Sender?.LogError($"Error in OnPrePurchase handler: {ex.Message}");
            }

            // If pause mode enabled, store the purchase and wait for ContinuePurchase()
            if (Instance.PauseBeforePurchase)
            {
                AdinmoManager.Sender?.LogInfo($"Purchase paused for: {item}. Call m_StoreController.ContinuePurchase(\"{item}\") to proceed.");
                Instance._pendingPurchases[item] = item;
                return;
            }

            // Default behavior: start purchase immediately
            AdinmoManager.Sender?.LogInfo($"Starting purchase for: {item}");
            Instance.PurchaseProduct(item);
        }

        /// <summary>
        /// Manually continue a paused purchase. Only needed when PauseBeforePurchase = true.
        /// Call this after completing your custom pre-purchase setup.
        /// </summary>
        /// <param name="productId">The product ID to purchase</param>
        [Preserve]
        public void ContinuePurchase(string productId)
        {
            if (!_pendingPurchases.ContainsKey(productId))
            {
                AdinmoManager.Sender?.LogWarning($"No pending purchase found for: {productId}");
                return;
            }

            _pendingPurchases.Remove(productId);
            AdinmoManager.Sender?.LogInfo($"Continuing paused purchase for: {productId}");
            PurchaseProduct(productId);
        }
    }
}
#endif