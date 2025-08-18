
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
    /// Main controller class that provides a unified interface for store operations, product management, and purchase handling.
    /// </summary>
    /// 
    [Preserve]
    public class AdinmoStoreController:StoreController 
    {
        public static AdinmoStoreController? Instance;
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
            if(Instance!= null)
            {
                Instance.PurchaseProduct(item);
            }
        }
    }
}
#endif