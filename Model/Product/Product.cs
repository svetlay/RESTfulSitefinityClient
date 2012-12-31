using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SFWinformsClient.Model.Product
{
        [DataContract]
    public class Description
    {
                    [DataMember]
        public string PersistedValue { get; set; }
                    [DataMember]
        public string Value { get; set; }
    }


        [DataContract]
    public class AlternativeText
    {
                    [DataMember]
        public string PersistedValue { get; set; }
                    [DataMember]
        public string Value { get; set; }
    }

        [DataContract]
    public class Thumbnail
    {
                    [DataMember]
        public object Album { get; set; }
                    [DataMember]
        public string AlbumId { get; set; }
                    [DataMember]
        public AlternativeText AlternativeText { get; set; }
                    [DataMember]
        public object FileName { get; set; }
                    [DataMember]
        public object FileSize { get; set; }
                    [DataMember]
        public int Height { get; set; }
                    [DataMember]
        public string Id { get; set; }
                    [DataMember]
        public object ImageDimensions { get; set; }
                    [DataMember]
        public int Ordinal { get; set; }
                    [DataMember]
        public int ThumbnailHeight { get; set; }
                    [DataMember]
        public object ThumbnailUrl { get; set; }
                    [DataMember]
        public int ThumbnailWidth { get; set; }
                    [DataMember]
        public object Title { get; set; }
                    [DataMember]
        public object UploadedDate { get; set; }
                    [DataMember]
        public string Url { get; set; }
                    [DataMember]
        public int Width { get; set; }
    }

    [DataContract]
    public class Title
    {
                    [DataMember]
        public string PersistedValue { get; set; }
                    [DataMember]
        public string Value { get; set; }
    }

        [DataContract]
    public class UrlName
    {
                    [DataMember]
        public string PersistedValue { get; set; }
                    [DataMember]
        public string Value { get; set; }
    }

    [DataContract]
    public class ProductItem
    {
            [DataMember]
        public string AssociateBuyerWithRole { get; set; }
            [DataMember]
        public List<string> AvailableLanguages { get; set; }
            [DataMember]
        public int BestSelling { get; set; }
                    [DataMember]
        public List<object> Department { get; set; }
                    [DataMember]
        public Description Description { get; set; }
                    [DataMember]
        public double DisplayPrice { get; set; }
                    [DataMember]
        public string DisplayPriceFormatted { get; set; }
                    [DataMember]
        public string DisplayPriceWithVatAndSale { get; set; }
                    [DataMember]
        public bool DisplayTaxInPrice { get; set; }
                    [DataMember]
        public bool Featured { get; set; }
                    [DataMember]
        public List<object> Files { get; set; }
                    [DataMember]
        public string Id { get; set; }
                    [DataMember]
        public List<object> Images { get; set; }
                    [DataMember]
        public bool IsActive { get; set; }
                    [DataMember]
        public bool IsOnSale { get; set; }
                    [DataMember]
        public string Owner { get; set; }
                    [DataMember]
        public double Price { get; set; }
                    [DataMember]
        public double PriceWithVatAndSale { get; set; }
                    [DataMember]
        public DateTime PublicationDate { get; set; }
                    [DataMember]
        public int Rating { get; set; }
                    [DataMember]
        public object SaleEndDate { get; set; }
                    [DataMember]
        public object SalePrice { get; set; }
                    [DataMember]
        public object SaleStartDate { get; set; }
                    [DataMember]
        public string Sku { get; set; }
                    [DataMember]
        public int Status { get; set; }
                    [DataMember]
        public List<object> Tags { get; set; }
                    [DataMember]
        public string TaxClassId { get; set; }
                    [DataMember]
        public Thumbnail Thumbnail { get; set; }
                    [DataMember]
        public Title Title { get; set; }
                    [DataMember]
        public UrlName UrlName { get; set; }

                    [DataMember]
        public int Version { get; set; }
                    [DataMember]
        public bool Visible { get; set; }
            [DataMember]
        public int Weight { get; set; }
    }

    [DataContract]
    public class Product
    {
        [DataMember]
        public ProductItem Item { get; set; }



    }

}
