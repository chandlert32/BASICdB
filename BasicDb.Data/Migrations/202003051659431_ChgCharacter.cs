﻿namespace BasicDb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChgCharacter : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Character", "CharItem_CharItemID", "dbo.CharItem");
            DropForeignKey("dbo.Item", "CharItem_CharItemID", "dbo.CharItem");
            DropForeignKey("dbo.Character", "CharMedia_CharMediaID", "dbo.CharMedia");
            DropForeignKey("dbo.Media", "CharMedia_CharMediaID", "dbo.CharMedia");
            DropIndex("dbo.Character", new[] { "CharItem_CharItemID" });
            DropIndex("dbo.Character", new[] { "CharMedia_CharMediaID" });
            DropIndex("dbo.Item", new[] { "CharItem_CharItemID" });
            DropIndex("dbo.Media", new[] { "CharMedia_CharMediaID" });
            DropColumn("dbo.Character", "CharItem_CharItemID");
            DropColumn("dbo.Character", "CharMedia_CharMediaID");
            DropColumn("dbo.Item", "CharItem_CharItemID");
            DropColumn("dbo.Media", "CharMedia_CharMediaID");
            DropTable("dbo.CharItem");
            DropTable("dbo.CharMedia");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CharMedia",
                c => new
                    {
                        CharMediaID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CharMediaID);
            
            CreateTable(
                "dbo.CharItem",
                c => new
                    {
                        CharItemID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CharItemID);
            
            AddColumn("dbo.Media", "CharMedia_CharMediaID", c => c.Int());
            AddColumn("dbo.Item", "CharItem_CharItemID", c => c.Int());
            AddColumn("dbo.Character", "CharMedia_CharMediaID", c => c.Int());
            AddColumn("dbo.Character", "CharItem_CharItemID", c => c.Int());
            CreateIndex("dbo.Media", "CharMedia_CharMediaID");
            CreateIndex("dbo.Item", "CharItem_CharItemID");
            CreateIndex("dbo.Character", "CharMedia_CharMediaID");
            CreateIndex("dbo.Character", "CharItem_CharItemID");
            AddForeignKey("dbo.Media", "CharMedia_CharMediaID", "dbo.CharMedia", "CharMediaID");
            AddForeignKey("dbo.Character", "CharMedia_CharMediaID", "dbo.CharMedia", "CharMediaID");
            AddForeignKey("dbo.Item", "CharItem_CharItemID", "dbo.CharItem", "CharItemID");
            AddForeignKey("dbo.Character", "CharItem_CharItemID", "dbo.CharItem", "CharItemID");
        }
    }
}
