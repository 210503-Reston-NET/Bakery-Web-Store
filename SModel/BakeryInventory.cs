namespace SModel
{
    public class BakeryInventory
    {
        public BakeryInventory()
        {
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