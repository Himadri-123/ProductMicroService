using static System.Net.Mime.MediaTypeNames;

namespace ProductMicroService.Entities
{
	public class Product
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int ActualPrice { get; set; }
		public int Discount { get; set; }
		public int DiscountPrice { get; set; }
		public int P_Active { get; set; }
		public byte[] Image { get; set; }
		public string Service { get; set; }
	}
}
