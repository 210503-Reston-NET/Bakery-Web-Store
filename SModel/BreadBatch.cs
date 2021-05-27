namespace SModel
{
    public class BreadBatch
    {
        public BreadBatch()
        {

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