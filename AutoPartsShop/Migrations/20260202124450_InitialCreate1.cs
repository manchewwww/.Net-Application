using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPartsShop.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:address_type.address_type", "shipping,billing")
                .Annotation("Npgsql:Enum:delivery_type.delivery_type", "address,office,locker,pickup_point")
                .Annotation("Npgsql:Enum:fitment_type.fitment_type", "direct_fit,requires_mod,universal")
                .Annotation("Npgsql:Enum:order_status.order_status", "new,paid,packing,shipped,delivered,cancelled,refunded")
                .Annotation("Npgsql:Enum:part_number_type.part_number_type", "oem,ean,upc,interchange,manufacturer")
                .Annotation("Npgsql:Enum:payment_status.payment_status", "pending,authorized,captured,failed,refunded")
                .Annotation("Npgsql:Enum:return_status.return_status", "requested,approved,received,rejected,refunded")
                .Annotation("Npgsql:Enum:shipment_status.shipment_status", "created,in_transit,delivered,lost,returned")
                .Annotation("Npgsql:Enum:stock_movement_type.stock_movement_type", "purchase,sale,return,adjustment,transfer_in,transfer_out,reserve,release")
                .OldAnnotation("Npgsql:Enum:address_type", "billing,shipping")
                .OldAnnotation("Npgsql:Enum:address_type.address_type", "shipping,billing")
                .OldAnnotation("Npgsql:Enum:delivery_type", "address,locker,office,pickup_point")
                .OldAnnotation("Npgsql:Enum:delivery_type.delivery_type", "address,office,locker,pickup_point")
                .OldAnnotation("Npgsql:Enum:fitment_type", "direct_fit,requires_mod,universal")
                .OldAnnotation("Npgsql:Enum:fitment_type.fitment_type", "direct_fit,requires_mod,universal")
                .OldAnnotation("Npgsql:Enum:order_status", "cancelled,delivered,new,packing,paid,refunded,shipped")
                .OldAnnotation("Npgsql:Enum:order_status.order_status", "new,paid,packing,shipped,delivered,cancelled,refunded")
                .OldAnnotation("Npgsql:Enum:part_number_type", "ean,interchange,manufacturer,oem,upc")
                .OldAnnotation("Npgsql:Enum:part_number_type.part_number_type", "oem,ean,upc,interchange,manufacturer")
                .OldAnnotation("Npgsql:Enum:payment_status", "authorized,captured,failed,pending,refunded")
                .OldAnnotation("Npgsql:Enum:payment_status.payment_status", "pending,authorized,captured,failed,refunded")
                .OldAnnotation("Npgsql:Enum:return_status", "approved,received,refunded,rejected,requested")
                .OldAnnotation("Npgsql:Enum:return_status.return_status", "requested,approved,received,rejected,refunded")
                .OldAnnotation("Npgsql:Enum:shipment_status", "created,delivered,in_transit,lost,returned")
                .OldAnnotation("Npgsql:Enum:shipment_status.shipment_status", "created,in_transit,delivered,lost,returned")
                .OldAnnotation("Npgsql:Enum:stock_movement_type", "adjustment,purchase,release,reserve,return,sale,transfer_in,transfer_out")
                .OldAnnotation("Npgsql:Enum:stock_movement_type.stock_movement_type", "purchase,sale,return,adjustment,transfer_in,transfer_out,reserve,release");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:address_type", "billing,shipping")
                .Annotation("Npgsql:Enum:address_type.address_type", "shipping,billing")
                .Annotation("Npgsql:Enum:delivery_type", "address,locker,office,pickup_point")
                .Annotation("Npgsql:Enum:delivery_type.delivery_type", "address,office,locker,pickup_point")
                .Annotation("Npgsql:Enum:fitment_type", "direct_fit,requires_mod,universal")
                .Annotation("Npgsql:Enum:fitment_type.fitment_type", "direct_fit,requires_mod,universal")
                .Annotation("Npgsql:Enum:order_status", "cancelled,delivered,new,packing,paid,refunded,shipped")
                .Annotation("Npgsql:Enum:order_status.order_status", "new,paid,packing,shipped,delivered,cancelled,refunded")
                .Annotation("Npgsql:Enum:part_number_type", "ean,interchange,manufacturer,oem,upc")
                .Annotation("Npgsql:Enum:part_number_type.part_number_type", "oem,ean,upc,interchange,manufacturer")
                .Annotation("Npgsql:Enum:payment_status", "authorized,captured,failed,pending,refunded")
                .Annotation("Npgsql:Enum:payment_status.payment_status", "pending,authorized,captured,failed,refunded")
                .Annotation("Npgsql:Enum:return_status", "approved,received,refunded,rejected,requested")
                .Annotation("Npgsql:Enum:return_status.return_status", "requested,approved,received,rejected,refunded")
                .Annotation("Npgsql:Enum:shipment_status", "created,delivered,in_transit,lost,returned")
                .Annotation("Npgsql:Enum:shipment_status.shipment_status", "created,in_transit,delivered,lost,returned")
                .Annotation("Npgsql:Enum:stock_movement_type", "adjustment,purchase,release,reserve,return,sale,transfer_in,transfer_out")
                .Annotation("Npgsql:Enum:stock_movement_type.stock_movement_type", "purchase,sale,return,adjustment,transfer_in,transfer_out,reserve,release")
                .OldAnnotation("Npgsql:Enum:address_type.address_type", "shipping,billing")
                .OldAnnotation("Npgsql:Enum:delivery_type.delivery_type", "address,office,locker,pickup_point")
                .OldAnnotation("Npgsql:Enum:fitment_type.fitment_type", "direct_fit,requires_mod,universal")
                .OldAnnotation("Npgsql:Enum:order_status.order_status", "new,paid,packing,shipped,delivered,cancelled,refunded")
                .OldAnnotation("Npgsql:Enum:part_number_type.part_number_type", "oem,ean,upc,interchange,manufacturer")
                .OldAnnotation("Npgsql:Enum:payment_status.payment_status", "pending,authorized,captured,failed,refunded")
                .OldAnnotation("Npgsql:Enum:return_status.return_status", "requested,approved,received,rejected,refunded")
                .OldAnnotation("Npgsql:Enum:shipment_status.shipment_status", "created,in_transit,delivered,lost,returned")
                .OldAnnotation("Npgsql:Enum:stock_movement_type.stock_movement_type", "purchase,sale,return,adjustment,transfer_in,transfer_out,reserve,release");
        }
    }
}
