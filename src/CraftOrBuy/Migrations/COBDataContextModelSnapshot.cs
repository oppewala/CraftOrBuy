using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CraftOrBuy.Data;

namespace CraftOrBuy.Migrations
{
    [DbContext(typeof(COBDataContext))]
    partial class COBDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CraftOrBuy.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlizzardItemId");

                    b.Property<string>("Description");

                    b.Property<bool>("IsAuctionable");

                    b.Property<int>("ItemBind");

                    b.Property<int?>("ItemClassId");

                    b.Property<string>("Name");

                    b.Property<int?>("RecipeId");

                    b.HasKey("Id");

                    b.HasIndex("ItemClassId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("CraftOrBuy.Models.ItemClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlizzardItemClassId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ItemClass");
                });

            modelBuilder.Entity("CraftOrBuy.Models.ItemSubClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlizzardItemSubClassId");

                    b.Property<int?>("ItemClassId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ItemClassId");

                    b.ToTable("ItemSubClass");
                });

            modelBuilder.Entity("CraftOrBuy.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlizzardRecipeId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("CraftOrBuy.Models.Item", b =>
                {
                    b.HasOne("CraftOrBuy.Models.ItemClass", "ItemClass")
                        .WithMany()
                        .HasForeignKey("ItemClassId");

                    b.HasOne("CraftOrBuy.Models.Recipe")
                        .WithMany("Materials")
                        .HasForeignKey("RecipeId");
                });

            modelBuilder.Entity("CraftOrBuy.Models.ItemSubClass", b =>
                {
                    b.HasOne("CraftOrBuy.Models.ItemClass")
                        .WithMany("SubClasses")
                        .HasForeignKey("ItemClassId");
                });
        }
    }
}
