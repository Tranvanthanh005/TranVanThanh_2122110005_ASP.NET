namespace TranVanThanh_2122110005.Model
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Image { get; set; }  // Thêm trường Image để lưu URL hoặc đường dẫn hình ảnh
    }
}
