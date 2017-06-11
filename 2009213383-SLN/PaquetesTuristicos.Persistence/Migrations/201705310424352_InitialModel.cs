namespace PaquetesTuristicos.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ComprobantesPago",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.Int(nullable: false),
                        TipoComprobante = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VentaPaquetes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false),
                        MediosPago = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ComprobantesPago", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombres = c.String(),
                        ApePaterno = c.String(),
                        ApeMaterno = c.String(),
                        Correo = c.String(),
                        Telefono = c.Int(nullable: false),
                        Dirección = c.String(),
                        Dni = c.Int(nullable: false),
                        NroCuenta = c.Int(),
                        EmpSueldo = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Paquetes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServicioTuristicos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.String(),
                        Hora = c.DateTime(nullable: false),
                        Direccion = c.String(),
                        CategoriaAlimentacion = c.Int(),
                        Descripcion = c.String(),
                        TipoHospedaje = c.Int(),
                        CalificacionHospedaje = c.Int(),
                        CategoriaHospedaje = c.Int(),
                        ServicioHospedaje = c.Int(),
                        DescripcionTransporte = c.String(),
                        TipoTransporte = c.Int(),
                        CategoriaTransporte = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VentaPaquetesClientes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.ClienteId })
                .ForeignKey("dbo.VentaPaquetes", t => t.Id, cascadeDelete: true)
                .ForeignKey("dbo.Persona", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.VentaPaquetesEmpleados",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        EmpleadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.EmpleadoId })
                .ForeignKey("dbo.VentaPaquetes", t => t.Id, cascadeDelete: true)
                .ForeignKey("dbo.Persona", t => t.EmpleadoId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.EmpleadoId);
            
            CreateTable(
                "dbo.PaquetesServiciosTuristicos",
                c => new
                    {
                        PaquetesId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PaquetesId, t.Id })
                .ForeignKey("dbo.Paquetes", t => t.PaquetesId, cascadeDelete: true)
                .ForeignKey("dbo.ServicioTuristicos", t => t.Id, cascadeDelete: true)
                .Index(t => t.PaquetesId)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.VentaPaquetesPaquetes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.Id })
                .ForeignKey("dbo.VentaPaquetes", t => t.Id, cascadeDelete: true)
                .ForeignKey("dbo.Paquetes", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VentaPaquetesPaquetes", "Id", "dbo.Paquetes");
            DropForeignKey("dbo.VentaPaquetesPaquetes", "Id", "dbo.VentaPaquetes");
            DropForeignKey("dbo.PaquetesServiciosTuristicos", "Id", "dbo.ServicioTuristicos");
            DropForeignKey("dbo.PaquetesServiciosTuristicos", "PaquetesId", "dbo.Paquetes");
            DropForeignKey("dbo.VentaPaquetesEmpleados", "EmpleadoId", "dbo.Persona");
            DropForeignKey("dbo.VentaPaquetesEmpleados", "Id", "dbo.VentaPaquetes");
            DropForeignKey("dbo.VentaPaquetes", "Id", "dbo.ComprobantesPago");
            DropForeignKey("dbo.VentaPaquetesClientes", "ClienteId", "dbo.Persona");
            DropForeignKey("dbo.VentaPaquetesClientes", "Id", "dbo.VentaPaquetes");
            DropIndex("dbo.VentaPaquetesPaquetes", new[] { "Id" });
            DropIndex("dbo.VentaPaquetesPaquetes", new[] { "Id" });
            DropIndex("dbo.PaquetesServiciosTuristicos", new[] { "Id" });
            DropIndex("dbo.PaquetesServiciosTuristicos", new[] { "PaquetesId" });
            DropIndex("dbo.VentaPaquetesEmpleados", new[] { "EmpleadoId" });
            DropIndex("dbo.VentaPaquetesEmpleados", new[] { "Id" });
            DropIndex("dbo.VentaPaquetesClientes", new[] { "ClienteId" });
            DropIndex("dbo.VentaPaquetesClientes", new[] { "Id" });
            DropIndex("dbo.VentaPaquetes", new[] { "Id" });
            DropTable("dbo.VentaPaquetesPaquetes");
            DropTable("dbo.PaquetesServiciosTuristicos");
            DropTable("dbo.VentaPaquetesEmpleados");
            DropTable("dbo.VentaPaquetesClientes");
            DropTable("dbo.ServicioTuristicos");
            DropTable("dbo.Paquetes");
            DropTable("dbo.Persona");
            DropTable("dbo.VentaPaquetes");
            DropTable("dbo.ComprobantesPago");
        }
    }
}
