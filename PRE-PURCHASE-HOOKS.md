# Pre-Purchase Event Hooks

**Version:** 3.2.315-beta.1

## Installation

```
https://github.com/AdInMo-Ltd/unity-plugin.git#v3.2.315-beta.1
```

## When to Use

Use `OnPrePurchase` event when you need to run custom logic before an IAP purchase starts:

- Attach product-specific callbacks before purchase flow begins
- Track analytics for IAPBoost ad purchases
- Set up reward handlers dynamically

## Usage

### Automatic Mode (Default)

Event fires and purchase continues immediately:

**Unity IAP v4:**
```csharp
AdInMoIapProxy.OnPrePurchase += (args) => {
    Debug.Log($"About to purchase: {args.ProductId}");
    AttachCallbacks(args.ProductId);
};
```

**Unity IAP v5:**
```csharp
var m_StoreController = new AdinmoStoreController();

m_StoreController.OnPrePurchase += (args) => {
    Debug.Log($"About to purchase: {args.ProductId}");
    AttachCallbacks(args.ProductId);
};
```

### Paused Mode (Advanced)

Purchase waits for manual confirmation:

**Unity IAP v4:**
```csharp
AdInMoIapProxy.PauseBeforePurchase = true;

AdInMoIapProxy.OnPrePurchase += (args) => {
    // Do validation/setup
    ValidateAsync(args.ProductId, () => {
        // Continue when ready
        AdInMoIapProxy.ContinuePurchase(args.ProductId);
    });
};
```

**Unity IAP v5:**
```csharp
var m_StoreController = new AdinmoStoreController();
m_StoreController.PauseBeforePurchase = true;

m_StoreController.OnPrePurchase += (args) => {
    // Do validation/setup
    ValidateAsync(args.ProductId, () => {
        // Continue when ready
        m_StoreController.ContinuePurchase(args.ProductId);
    });
};
```

**Note:** If you don't call `ContinuePurchase()`, the purchase will not start.

## API

```csharp
public class PrePurchaseEventArgs
{
    public string ProductId { get; }
    public Product Product { get; }
}
```

## Backward Compatible

✅ Event is optional - existing code works without changes.

For advanced control options, contact support@adinmo.com
