namespace SModel
{
    public class BreadBatch
    {
        public BreadBatch()
        {

        }
        public BreadBatch(int oID, int productNum, int quantity)
        {
            OrderId = oID;
            ProductId = productNum;
            BreadQuantity = quantity;
        }

        //Primary Key
        public int BreadBatchId { get; set; }

        //attribute
        public int? BreadQuantity { get; set; }

        //Foreign Keys
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
    }
}