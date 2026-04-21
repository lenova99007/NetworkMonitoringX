using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace NetworkMonitoring.Shared.Migrations
{
    public partial class FullInitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Country",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Suspend = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "T_DeviceTypes",
                columns: table => new
                {
                    DeviceTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Suspend = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_DeviceTypes", x => x.DeviceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "T_Login",
                columns: table => new
                {
                    LoginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Pwd = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FName_EN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LName_EN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FName_AR = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LName_AR = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Suspend = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Login", x => x.LoginId);
                });

            migrationBuilder.CreateTable(
                name: "T_Location",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    LocationName_En = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LocationName_Ar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Suspend = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Location", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_T_Location_T_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "T_Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_Device",
                columns: table => new
                {
                    DeviceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceTypeId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    DeviceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Suspend = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Device", x => x.DeviceId);
                    table.ForeignKey(
                        name: "FK_T_Device_T_DeviceTypes_DeviceTypeId",
                        column: x => x.DeviceTypeId,
                        principalTable: "T_DeviceTypes",
                        principalColumn: "DeviceTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_Device_T_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "T_Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_ActivityTypes",
                columns: table => new
                {
                    ActivityTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    Timer = table.Column<int>(type: "int", nullable: true),
                    Suspend = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ActivityTypes", x => x.ActivityTypeId);
                });

            // Logs tables
            migrationBuilder.CreateTable(
                name: "T_PingLogs",
                columns: table => new
                {
                    PingLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceId = table.Column<int>(type: "int", nullable: true),
                    ResultMessage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsIssue = table.Column<bool>(type: "bit", nullable: false),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    IsSuspended = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PingLogs", x => x.PingLogId);
                    table.ForeignKey(
                        name: "FK_T_PingLogs_T_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "T_Device",
                        principalColumn: "DeviceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "T_HttpLogs",
                columns: table => new
                {
                    HttpLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceId = table.Column<int>(type: "int", nullable: true),
                    ResultMessage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsIssue = table.Column<bool>(type: "bit", nullable: false),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    IsSuspended = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_HttpLogs", x => x.HttpLogId);
                    table.ForeignKey(
                        name: "FK_T_HttpLogs_T_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "T_Device",
                        principalColumn: "DeviceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "T_HddLogs",
                columns: table => new
                {
                    HddLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceId = table.Column<int>(type: "int", nullable: true),
                    HDDInfo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    IsSuspended = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_HddLogs", x => x.HddLogId);
                    table.ForeignKey(
                        name: "FK_T_HddLogs_T_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "T_Device",
                        principalColumn: "DeviceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "T_DbLogs",
                columns: table => new
                {
                    DbLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceId = table.Column<int>(type: "int", nullable: true),
                    DbSizeInfo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    IsSuspended = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_DbLogs", x => x.DbLogId);
                    table.ForeignKey(
                        name: "FK_T_DbLogs_T_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "T_Device",
                        principalColumn: "DeviceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "T_ServicesLogs",
                columns: table => new
                {
                    ServicesLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceId = table.Column<int>(type: "int", nullable: true),
                    ResultMessage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    IsSuspended = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ServicesLogs", x => x.ServicesLogId);
                    table.ForeignKey(
                        name: "FK_T_ServicesLogs_T_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "T_Device",
                        principalColumn: "DeviceId",
                        onDelete: ReferentialAction.Restrict);
                });

            // Functions, SubFunctions, Access
            migrationBuilder.CreateTable(
                name: "T_Functions",
                columns: table => new
                {
                    FunctionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FunctionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DisplayName_En = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DisplayName_Ar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FunctionIcon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FunctionLink = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Suspend = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsInMenu = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Functions", x => x.FunctionId);
                });

            migrationBuilder.CreateTable(
                name: "T_SubFunctions",
                columns: table => new
                {
                    SubFunctionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FunctionId = table.Column<int>(type: "int", nullable: false),
                    SubFunctionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DisplayName_En = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DisplayName_Ar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SubFunctionIcon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SubFunctionLink = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsInMenu = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Suspend = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_SubFunctions", x => x.SubFunctionId);
                    table.ForeignKey(
                        name: "FK_T_SubFunctions_T_Functions_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "T_Functions",
                        principalColumn: "FunctionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_FunctionsAccess",
                columns: table => new
                {
                    AccessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FunctionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_FunctionsAccess", x => x.AccessId);
                    table.ForeignKey(
                        name: "FK_T_FunctionsAccess_T_Functions_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "T_Functions",
                        principalColumn: "FunctionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_FunctionsAccess_T_Login_UserId",
                        column: x => x.UserId,
                        principalTable: "T_Login",
                        principalColumn: "LoginId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_SubFunctionsAccess",
                columns: table => new
                {
                    AccessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubFunctionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_SubFunctionsAccess", x => x.AccessId);
                    table.ForeignKey(
                        name: "FK_T_SubFunctionsAccess_T_SubFunctions_SubFunctionId",
                        column: x => x.SubFunctionId,
                        principalTable: "T_SubFunctions",
                        principalColumn: "SubFunctionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_SubFunctionsAccess_T_Login_UserId",
                        column: x => x.UserId,
                        principalTable: "T_Login",
                        principalColumn: "LoginId",
                        onDelete: ReferentialAction.Cascade);
                });

            // Grid setup
            migrationBuilder.CreateTable(
                name: "T_GridSetup",
                columns: table => new
                {
                    GridSetupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColumnId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TColumnHidden = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ColumnNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColumnNameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColumnWidth = table.Column<byte>(type: "tinyint", nullable: true),
                    ColumnSort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormatType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormatString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SummaryType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expression = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Visible = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    VisibleIndex = table.Column<byte>(type: "tinyint", nullable: true),
                    Suspend = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_GridSetup", x => x.GridSetupId);
                });

            migrationBuilder.CreateTable(
                name: "T_GridUserLayout",
                columns: table => new
                {
                    UserLayoutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GridLayoutData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suspend = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_GridUserLayout", x => x.UserLayoutId);
                });

            // Chat, Docs, Approval, Sequences
            migrationBuilder.CreateTable(
                name: "T_ChatMessages",
                columns: table => new
                {
                    ChatMessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    MessageText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ChatMessages", x => x.ChatMessageId);
                    table.ForeignKey(
                        name: "FK_T_ChatMessages_T_Login_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "T_Login",
                        principalColumn: "LoginId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_ChatMessages_T_Login_SenderId",
                        column: x => x.SenderId,
                        principalTable: "T_Login",
                        principalColumn: "LoginId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_Documents",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Documents", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_T_Documents_T_Login_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "T_Login",
                        principalColumn: "LoginId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_ApprovalRequests",
                columns: table => new
                {
                    ApprovalRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequesterId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ApprovalRequests", x => x.ApprovalRequestId);
                    table.ForeignKey(
                        name: "FK_T_ApprovalRequests_T_Login_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "T_Login",
                        principalColumn: "LoginId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_Sequences",
                columns: table => new
                {
                    SequencesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PreFix = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Sequences", x => x.SequencesId);
                });

            // Indexes
            migrationBuilder.CreateIndex(name: "IX_T_Device_DeviceTypeId", table: "T_Device", column: "DeviceTypeId");
            migrationBuilder.CreateIndex(name: "IX_T_Device_LocationId", table: "T_Device", column: "LocationId");
            migrationBuilder.CreateIndex(name: "IX_T_Location_CountryId", table: "T_Location", column: "CountryId");
            migrationBuilder.CreateIndex(name: "IX_T_PingLogs_DeviceId", table: "T_PingLogs", column: "DeviceId");
            migrationBuilder.CreateIndex(name: "IX_T_HttpLogs_DeviceId", table: "T_HttpLogs", column: "DeviceId");
            migrationBuilder.CreateIndex(name: "IX_T_HddLogs_DeviceId", table: "T_HddLogs", column: "DeviceId");
            migrationBuilder.CreateIndex(name: "IX_T_DbLogs_DeviceId", table: "T_DbLogs", column: "DeviceId");
            migrationBuilder.CreateIndex(name: "IX_T_ServicesLogs_DeviceId", table: "T_ServicesLogs", column: "DeviceId");
            migrationBuilder.CreateIndex(name: "IX_T_SubFunctions_FunctionId", table: "T_SubFunctions", column: "FunctionId");
            migrationBuilder.CreateIndex(name: "IX_T_FunctionsAccess_FunctionId", table: "T_FunctionsAccess", column: "FunctionId");
            migrationBuilder.CreateIndex(name: "IX_T_FunctionsAccess_UserId", table: "T_FunctionsAccess", column: "UserId");
            migrationBuilder.CreateIndex(name: "IX_T_SubFunctionsAccess_SubFunctionId", table: "T_SubFunctionsAccess", column: "SubFunctionId");
            migrationBuilder.CreateIndex(name: "IX_T_SubFunctionsAccess_UserId", table: "T_SubFunctionsAccess", column: "UserId");
            migrationBuilder.CreateIndex(name: "IX_T_ChatMessages_ReceiverId", table: "T_ChatMessages", column: "ReceiverId");
            migrationBuilder.CreateIndex(name: "IX_T_ChatMessages_SenderId", table: "T_ChatMessages", column: "SenderId");
            migrationBuilder.CreateIndex(name: "IX_T_Documents_OwnerId", table: "T_Documents", column: "OwnerId");
            migrationBuilder.CreateIndex(name: "IX_T_ApprovalRequests_RequesterId", table: "T_ApprovalRequests", column: "RequesterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "T_ApprovalRequests");
            migrationBuilder.DropTable(name: "T_ChatMessages");
            migrationBuilder.DropTable(name: "T_Documents");
            migrationBuilder.DropTable(name: "T_GridSetup");
            migrationBuilder.DropTable(name: "T_GridUserLayout");
            migrationBuilder.DropTable(name: "T_FunctionsAccess");
            migrationBuilder.DropTable(name: "T_SubFunctionsAccess");
            migrationBuilder.DropTable(name: "T_SubFunctions");
            migrationBuilder.DropTable(name: "T_Functions");
            migrationBuilder.DropTable(name: "T_ServicesLogs");
            migrationBuilder.DropTable(name: "T_DbLogs");
            migrationBuilder.DropTable(name: "T_HddLogs");
            migrationBuilder.DropTable(name: "T_HttpLogs");
            migrationBuilder.DropTable(name: "T_PingLogs");
            migrationBuilder.DropTable(name: "T_ActivityTypes");
            migrationBuilder.DropTable(name: "T_Device");
            migrationBuilder.DropTable(name: "T_DeviceTypes");
            migrationBuilder.DropTable(name: "T_Location");
            migrationBuilder.DropTable(name: "T_Country");
            migrationBuilder.DropTable(name: "T_Login");
            migrationBuilder.DropTable(name: "T_Sequences");
        }
    }
}
