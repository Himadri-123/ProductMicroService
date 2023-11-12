namespace ProductMicroService.Entities.Response
{
	public class ProductResponse
	{
		public int P_ID { get; set; }
		public string P_Name { get; set; }
		public string P_Description { get; set; }
		public int P_ActualPrice { get; set; }
		public int P_Discount { get; set; }
		public int P_DiscountPrice { get; set; }
		public int P_Active { get; set; }
		public byte[] P_Image { get; set; }
		public string P_Service { get; set; }
	}
}
