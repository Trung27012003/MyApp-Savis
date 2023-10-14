using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyApp.Shared.Models;
using System.Data;

namespace MyApp.Api.Data
{
    public class MyDbContext : IdentityDbContext<UserModel, RoleModel, Guid>
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            Create(builder);

        }
        private void Create(ModelBuilder builder)
        {
            builder.Entity<RoleModel>().HasData(
                 new RoleModel() { Id = Guid.NewGuid(), Name = "Admin", NormalizedName = "ADMIN" },
                 new RoleModel() { Id = Guid.NewGuid(), Name = "User", NormalizedName = "USER" },
                 new RoleModel() { Id = Guid.NewGuid(), Name = "Guest", NormalizedName = "GUEST" }
             );
            builder.Entity<OrderStatusModel>().HasData(
                new OrderStatusModel() { Id = Guid.NewGuid(), OrderStatusName = "Đang được xử    lý" },
                new OrderStatusModel() { Id = Guid.NewGuid(), OrderStatusName = "Chờ lấy hàng" },
                new OrderStatusModel() { Id = Guid.NewGuid(), OrderStatusName = "Đang giao hàng" },
                new OrderStatusModel() { Id = Guid.NewGuid(), OrderStatusName = "Giao hàng thành công" },
                new OrderStatusModel() { Id = Guid.NewGuid(), OrderStatusName = "Giao hàng không thành công" },
                new OrderStatusModel() { Id = Guid.NewGuid(), OrderStatusName = "Hủy đơn" },
                new OrderStatusModel() { Id = Guid.NewGuid(), OrderStatusName = "Yêu cầu trả hàng" },
                new OrderStatusModel() { Id = Guid.NewGuid(), OrderStatusName = "Chấp nhận trả hàng" }
            );
            builder.Entity<CategoryModel>().HasData(
               new CategoryModel() { Id = Guid.NewGuid(), CategoryName = "Category 1" },
               new CategoryModel() { Id = Guid.NewGuid(), CategoryName = "Category 2" },
               new CategoryModel() { Id = Guid.NewGuid(), CategoryName = "Category 3" },
               new CategoryModel() { Id = Guid.NewGuid(), CategoryName = "Category 4" },
               new CategoryModel() { Id = Guid.NewGuid(), CategoryName = "Category 5" }
           );
            builder.Entity<PaymentModel>().HasData(
                    new PaymentModel() { Id = Guid.NewGuid(), PaymentName = "Thanh toán khi nhận hàng" },
                    new PaymentModel() { Id = Guid.NewGuid(), PaymentName = "Thanh toán Online" }
                );
            builder.Entity<ColorModel>().HasData(
               new ColorModel() { ColorId = Guid.NewGuid(), ColorName = "Đen", ColorCode = "#000000" },
               new ColorModel() { ColorId = Guid.NewGuid(), ColorName = "Trắng", ColorCode = "#FFFFFF" },
               new ColorModel() { ColorId = Guid.NewGuid(), ColorName = "Đỏ", ColorCode = "#FF0000" },
               new ColorModel() { ColorId = Guid.NewGuid(), ColorName = "Xanh lá cây", ColorCode = "#00FF00" },
               new ColorModel() { ColorId = Guid.NewGuid(), ColorName = "Xanh dương", ColorCode = "#0000FF" },
               new ColorModel() { ColorId = Guid.NewGuid(), ColorName = "Vàng", ColorCode = "#FFFF00" },
               new ColorModel() { ColorId = Guid.NewGuid(), ColorName = "Cam", ColorCode = "#FFA500" },
               new ColorModel() { ColorId = Guid.NewGuid(), ColorName = "Tím", ColorCode = "#800080" },
               new ColorModel() { ColorId = Guid.NewGuid(), ColorName = "Hồng", ColorCode = "#FFC0CB" },
               new ColorModel() { ColorId = Guid.NewGuid(), ColorName = "Xám", ColorCode = "#808080" },
               new ColorModel() { ColorId = Guid.NewGuid(), ColorName = "Nâu", ColorCode = "#A52A2A" },
               new ColorModel() { ColorId = Guid.NewGuid(), ColorName = "Xanh lam", ColorCode = "#000080" },
               new ColorModel() { ColorId = Guid.NewGuid(), ColorName = "Xanh da trời", ColorCode = "#00BFFF" },
               new ColorModel() { ColorId = Guid.NewGuid(), ColorName = "Hồng phấn", ColorCode = "#FFDAB9" },
               new ColorModel() { ColorId = Guid.NewGuid(), ColorName = "Xám tro", ColorCode = "#C0C0C0" },
               new ColorModel() { ColorId = Guid.NewGuid(), ColorName = "Bạc", ColorCode = "#C0C0C0" }
                );
            builder.Entity<VoucherStatusModel>().HasData(
                   new VoucherStatusModel() { Id = Guid.NewGuid(), Name = "Used" },
                   new VoucherStatusModel() { Id = Guid.NewGuid(), Name = "Active" },
                   new VoucherStatusModel() { Id = Guid.NewGuid(), Name = "Expired" }
               );
        }
        public DbSet<CartItemModel> CartItems { get; set; }
        public DbSet<CartModel> Cart { get; set; }
        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<ColorModel> Colors { get; set; }
        public DbSet<OrderModel > Order { get; set; }
        public DbSet<OrderItemModel> OrderItem { get; set; }
        public DbSet<OrderStatusModel> OrderStatus { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<PaymentModel> Payments { get; set; }
        public DbSet<ProductDetailModel> ProductDetails { get; set; }
        public DbSet<ProductImageModel> ProductImages { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<UserVoucherModel> UserVouche { get; set; }
        public DbSet<VoucherModel> VoucherModel { get; set; }
        public DbSet<VoucherProductModel> VoucherProduct { get; set; }
        public DbSet<VoucherStatusModel> VoucherStatus { get; set; }
        public DbSet<VoucherTypeModel> VoucherType { get; set; }
    }
}
