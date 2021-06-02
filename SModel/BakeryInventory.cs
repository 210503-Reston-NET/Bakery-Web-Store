namespace SModel
{
    public class BakeryInventory
    {
        public BakeryInventory()
        {
        }
        public BakeryInventory(int storeId, int productId, int stock)
        {
            Stock = stock;
            ProductId = productId;
            StoreId = storeId;
        }

        //Primary Key
        public int Id { get; set; }
        
        //Attribute
        public int Stock { get; set; }

        //Foreign Keys
        public int ProductId { get; set; }
        public int StoreId { get; set; }

    }
}