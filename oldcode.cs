public class ProductReturn
    {
        // Constructor
        public ProductReturn(int initProductID, int initCategoryID, string initName, string initType, string initPlatform, int  initAmountAvailable, decimal initPrice, string initDescription, string initImageFile)
        {
            ProductID = initProductID;
            CategoryID = initCategoryID;
            Name = initName;
            Type = initType;
            Platform = initPlatform;
            AmountAvailable = initAmountAvailable;
            Price = initPrice;
            Description = initDescription;
            ImageFile = initImageFile;
        }

        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Platform { get; set; }
        public int AmountAvailable { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
    }

return new ProductReturn((int)read["ProductID"],
                (int)read["CategoryID"],
                read["Name"].ToString(),
                read["Type"].ToString(),
                read["Platform"].ToString(),
                (int)read["AmountAvailable"],
                (decimal)read["Price"],
                read["Description"].ToString(),
                read["ImageFile"].ToString());