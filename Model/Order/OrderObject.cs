using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFWinformsClient.Model.Order
{
    public class Address
    {
       
        public string Address2 { get; set; }
        public int AddressType { get; set; }
        public string ApplicationName { get; set; }
        public string City { get; set; }
        public string Company { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Id { get; set; }
        public DateTime LastModified { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public object PhoneExtension { get; set; }
        public string PostalCode { get; set; }
        public string StateRegion { get; set; }
    }

    public class CustomerSummary
    {
        public string CustomerEmail { get; set; }
        public string CustomerName { get; set; }
        public object ImageUrl { get; set; }
        public string ProfileId { get; set; }
    }

    public class AlternativeText
    {
        public string PersistedValue { get; set; }
        public string Value { get; set; }
    }

    public class ProductImage
    {
        public object Album { get; set; }
        public string AlbumId { get; set; }
        public AlternativeText AlternativeText { get; set; }
        public object FileName { get; set; }
        public object FileSize { get; set; }
        public int Height { get; set; }
        public string Id { get; set; }
        public object ImageDimensions { get; set; }
        public int Ordinal { get; set; }
        public int ThumbnailHeight { get; set; }
        public object ThumbnailUrl { get; set; }
        public int ThumbnailWidth { get; set; }
        public object Title { get; set; }
        public object UploadedDate { get; set; }
        public string Url { get; set; }
        public int Width { get; set; }
    }

    public class Detail
    {
        public string ApplicationName { get; set; }
        public double BasePrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public double DeltaPrice { get; set; }
        public string DisplayPriceFormatted { get; set; }
        public string DisplayTotalFormatted { get; set; }
        public string Id { get; set; }
        public bool IsOnSale { get; set; }
        public bool IsShippable { get; set; }
        public DateTime LastModified { get; set; }
        public string Options { get; set; }
        public double Price { get; set; }
        public string PriceFormatted { get; set; }
        public string ProductId { get; set; }
        public ProductImage ProductImage { get; set; }
        public int Quantity { get; set; }
        public string Sku { get; set; }
        public string TaxClassId { get; set; }
        public bool TaxInPrice { get; set; }
        public int TaxRate { get; set; }
        public string Title { get; set; }
        public double Total { get; set; }
        public string TotalFormatted { get; set; }
        public string VariantAsIds { get; set; }
        public string VariantAsNames { get; set; }
        public double Weight { get; set; }
    }

    public class Payment
    {
        public string ApplicationName { get; set; }
        public string CreditCardNumberLastFour { get; set; }
        public string CreditCardNumberPreview { get; set; }
        public int CreditCardType { get; set; }
        public string CreditCardTypeName { get; set; }
        public string Id { get; set; }
        public DateTime LastModified { get; set; }
        public string PaymentMethodFormatted { get; set; }
        public int PaymentMethodType { get; set; }
        public bool SuccessfulPayment { get; set; }
    }

    public class OrderItem
    {
        public List<Address> Addresses { get; set; }
        public string Currency { get; set; }
        public string CurrencyInfo { get; set; }
        public string CustomerName { get; set; }
        public CustomerSummary CustomerSummary { get; set; }
        public List<Detail> Details { get; set; }
        public int DiscountTotal { get; set; }
        public string DiscountTotalFormatted { get; set; }
        public List<object> Discounts { get; set; }
        public int EffectiveTaxRate { get; set; }
        public string Id { get; set; }
        public bool IsShippable { get; set; }
        public int OrderAttempts { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }
        public int OrderStatus { get; set; }
        public string OrderStatusTitle { get; set; }
        public List<Payment> Payments { get; set; }
        public int PreDiscountTax { get; set; }
        public double PreTaxPrice { get; set; }
        public string PreTaxPriceFormatted { get; set; }
        public double PreTaxTotal { get; set; }
        public string PreTaxTotalFormatted { get; set; }
        public object Profile { get; set; }
        public object ShippedOn { get; set; }
        public string ShippedOnString { get; set; }
        public string ShippingCarrierName { get; set; }
        public string ShippingServiceName { get; set; }
        public double ShippingTotal { get; set; }
        public string ShippingTotalFormatted { get; set; }
        public bool ShowShippedOn { get; set; }
        public double SubTotalDisplay { get; set; }
        public string SubTotalFormatted { get; set; }
        public int Tax { get; set; }
        public string TaxFormatted { get; set; }
        public double Total { get; set; }
        public string TotalFormatted { get; set; }
        public int TotalItemsInOrder { get; set; }
        public double Weight { get; set; }

        public override string ToString()
        {
            return "Order #" + OrderNumber + " by " + CustomerName;
        }
    }

    public class OrderObject
    {
        public object Context { get; set; }
        public bool IsGeneric { get; set; }
        public List<OrderItem> Items { get; set; }
        public int TotalCount { get; set; }

    
    }



}
