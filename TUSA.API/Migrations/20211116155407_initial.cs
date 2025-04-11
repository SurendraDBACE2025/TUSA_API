using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TUSA.API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "business_unit_master",
                columns: table => new
                {
                    business_unit_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    business_unit_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    business_unit_desc = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_business_unit_master", x => x.business_unit_id);
                });

            migrationBuilder.CreateTable(
                name: "continent_master",
                columns: table => new
                {
                    continent_code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    continent_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    continent_desc = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_continent_master", x => x.continent_code);
                });

            migrationBuilder.CreateTable(
                name: "currency_conversion",
                columns: table => new
                {
                    exchange_rate_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    from_currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    to_currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    is_active = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currency_conversion", x => x.exchange_rate_id);
                });

            migrationBuilder.CreateTable(
                name: "dynamic_form_data",
                columns: table => new
                {
                    module_id = table.Column<int>(type: "int", nullable: false),
                    field_id = table.Column<int>(type: "int", nullable: false),
                    Record_id = table.Column<int>(type: "int", nullable: false),
                    form_name = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    filed_value = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dynamic_form_data", x => new { x.module_id, x.field_id, x.Record_id });
                });

            migrationBuilder.CreateTable(
                name: "field_master",
                columns: table => new
                {
                    field_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    field_title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    field_data_type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    field_length = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    is_dropdown = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    reference_if_dropdown = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ref_filed_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    is_active = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_field_master", x => x.field_id);
                });

            migrationBuilder.CreateTable(
                name: "form_field_matrix",
                columns: table => new
                {
                    module_id = table.Column<int>(type: "int", nullable: false),
                    form_name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    field_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    is_active = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    nullable = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    field_order = table.Column<int>(type: "int", nullable: false),
                    comments_available = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    field_comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    field_design_type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    field_validation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_form_field_matrix", x => new { x.module_id, x.form_name, x.field_id });
                });

            migrationBuilder.CreateTable(
                name: "group_form_access_matrix",
                columns: table => new
                {
                    form_id = table.Column<int>(type: "int", nullable: false),
                    group_id = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group_form_access_matrix", x => new { x.group_id, x.form_id });
                });

            migrationBuilder.CreateTable(
                name: "group_type_master",
                columns: table => new
                {
                    group_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    group_type_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group_type_master", x => x.group_type_id);
                });

            migrationBuilder.CreateTable(
                name: "module_master",
                columns: table => new
                {
                    module_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    module_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    module_desc = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_module_master", x => x.module_id);
                });

            migrationBuilder.CreateTable(
                name: "pdc_category_master",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pdc_category_master", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "pending_groups",
                columns: table => new
                {
                    pending_group_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    group_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    organization_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_First_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_activated = table.Column<bool>(type: "bit", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pending_groups", x => x.pending_group_ID);
                });

            migrationBuilder.CreateTable(
                name: "project_phase_master",
                columns: table => new
                {
                    project_phase_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    project_phase_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    project_phase_desc = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_phase_master", x => x.project_phase_id);
                });

            migrationBuilder.CreateTable(
                name: "project_scope_master",
                columns: table => new
                {
                    project_scope_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    project_scope_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    project_scope_desc = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_scope_master", x => x.project_scope_id);
                });

            migrationBuilder.CreateTable(
                name: "project_type_master",
                columns: table => new
                {
                    project_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    project_type_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    project_type_desc = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_type_master", x => x.project_type_id);
                });

            migrationBuilder.CreateTable(
                name: "role_master",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_master", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "user_type_master",
                columns: table => new
                {
                    user_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_type_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_type_master", x => x.user_type_id);
                });

            migrationBuilder.CreateTable(
                name: "country_master",
                columns: table => new
                {
                    country_code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    country_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    hvec_flag = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    continent_code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    continent_mastercontinent_code = table.Column<string>(type: "nvarchar(2)", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country_master", x => x.country_code);
                    table.ForeignKey(
                        name: "FK_country_master_continent_master_continent_mastercontinent_code",
                        column: x => x.continent_mastercontinent_code,
                        principalTable: "continent_master",
                        principalColumn: "continent_code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "name_value_pair",
                columns: table => new
                {
                    field_id = table.Column<int>(type: "int", nullable: false),
                    field_masterfield_id = table.Column<int>(type: "int", nullable: true),
                    value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_name_value_pair_field_master_field_masterfield_id",
                        column: x => x.field_masterfield_id,
                        principalTable: "field_master",
                        principalColumn: "field_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "group_master",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    group_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    display_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    group_type_id = table.Column<int>(type: "int", nullable: false),
                    group_type_id1 = table.Column<int>(type: "int", nullable: true),
                    group_desc = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    organization_name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    is_active = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    is_deleted = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group_master", x => x.group_id);
                    table.ForeignKey(
                        name: "FK_group_master_group_type_master_group_type_id1",
                        column: x => x.group_type_id1,
                        principalTable: "group_type_master",
                        principalColumn: "group_type_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "forms_master",
                columns: table => new
                {
                    form_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    module_id = table.Column<int>(type: "int", nullable: false),
                    module_mastermodule_id = table.Column<int>(type: "int", nullable: true),
                    form_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    form_desc = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    is_active = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_forms_master", x => x.form_id);
                    table.ForeignKey(
                        name: "FK_forms_master_module_master_module_mastermodule_id",
                        column: x => x.module_mastermodule_id,
                        principalTable: "module_master",
                        principalColumn: "module_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pdc_element_master",
                columns: table => new
                {
                    element_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    pdc_category_mastercategory_id = table.Column<int>(type: "int", nullable: true),
                    element_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    element_order_no = table.Column<int>(type: "int", nullable: false),
                    phase = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    units = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    service_or_equipment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pdc_element_master", x => x.element_id);
                    table.ForeignKey(
                        name: "FK_pdc_element_master_pdc_category_master_pdc_category_mastercategory_id",
                        column: x => x.pdc_category_mastercategory_id,
                        principalTable: "pdc_category_master",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pending_groups_mails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pending_group_ID = table.Column<int>(type: "int", nullable: false),
                    pending_Groupspending_group_ID = table.Column<int>(type: "int", nullable: true),
                    mail_status = table.Column<bool>(type: "bit", nullable: false),
                    mail_sendedat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pending_groups_mails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_pending_groups_mails_pending_groups_pending_Groupspending_group_ID",
                        column: x => x.pending_Groupspending_group_ID,
                        principalTable: "pending_groups",
                        principalColumn: "pending_group_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_master",
                columns: table => new
                {
                    user_email_id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    contact_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    user_type_id = table.Column<int>(type: "int", nullable: true),
                    user_type_masteruser_type_id = table.Column<int>(type: "int", nullable: true),
                    last_login_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    password_changed_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activation_code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    reset_password_date = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    last_reset_attempt_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    refresh_token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    refresh_token_expiryat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_activated = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    is_active = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    is_deleted = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_master", x => x.user_email_id);
                    table.ForeignKey(
                        name: "FK_user_master_user_type_master_user_type_masteruser_type_id",
                        column: x => x.user_type_masteruser_type_id,
                        principalTable: "user_type_master",
                        principalColumn: "user_type_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "currency_master",
                columns: table => new
                {
                    currency_code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    currency_symbol = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    currency_desc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    country_code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    country_mastercountry_code = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currency_master", x => x.currency_code);
                    table.ForeignKey(
                        name: "FK_currency_master_country_master_country_mastercountry_code",
                        column: x => x.country_mastercountry_code,
                        principalTable: "country_master",
                        principalColumn: "country_code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "site_master",
                columns: table => new
                {
                    site_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    site_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    country_code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    country_mastercountry_code = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    langitude = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    latitude = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    site_desc = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_site_master", x => x.site_id);
                    table.ForeignKey(
                        name: "FK_site_master_country_master_country_mastercountry_code",
                        column: x => x.country_mastercountry_code,
                        principalTable: "country_master",
                        principalColumn: "country_code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pdc_form_category_matrix",
                columns: table => new
                {
                    matrix_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    form_id = table.Column<int>(type: "int", nullable: false),
                    forms_masterform_id = table.Column<int>(type: "int", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    pdc_category_mastercategory_id = table.Column<int>(type: "int", nullable: true),
                    caotegory_order_no = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pdc_form_category_matrix", x => x.matrix_id);
                    table.ForeignKey(
                        name: "FK_pdc_form_category_matrix_forms_master_forms_masterform_id",
                        column: x => x.forms_masterform_id,
                        principalTable: "forms_master",
                        principalColumn: "form_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pdc_form_category_matrix_pdc_category_master_pdc_category_mastercategory_id",
                        column: x => x.pdc_category_mastercategory_id,
                        principalTable: "pdc_category_master",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pdc_header_data",
                columns: table => new
                {
                    header_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    form_id = table.Column<int>(type: "int", nullable: false),
                    forms_masterform_id = table.Column<int>(type: "int", nullable: true),
                    supplier_group = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    project_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    project_year = table.Column<int>(type: "int", nullable: true),
                    currency = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    total_project_cost = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    year_1_onm_price = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    year_2_onm_price = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    installed_capacity_dc = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    installed_capacity_ac = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    year_1_yield = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    guaranteed_perf_ratio = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    minimum_perf_ratio = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    guaranteed_availability = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    cod = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pdc_header_data", x => x.header_Id);
                    table.ForeignKey(
                        name: "FK_pdc_header_data_forms_master_forms_masterform_id",
                        column: x => x.forms_masterform_id,
                        principalTable: "forms_master",
                        principalColumn: "form_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "quick_access_screens",
                columns: table => new
                {
                    user_email_id = table.Column<int>(type: "int", nullable: false),
                    user_masteruser_email_id = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    form_id = table.Column<int>(type: "int", nullable: false),
                    forms_masterform_id = table.Column<int>(type: "int", nullable: true),
                    form_list_order = table.Column<int>(type: "int", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_quick_access_screens_forms_master_forms_masterform_id",
                        column: x => x.forms_masterform_id,
                        principalTable: "forms_master",
                        principalColumn: "form_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_quick_access_screens_user_master_user_masteruser_email_id",
                        column: x => x.user_masteruser_email_id,
                        principalTable: "user_master",
                        principalColumn: "user_email_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "recently_accessed_screens",
                columns: table => new
                {
                    user_email_id = table.Column<int>(type: "int", nullable: false),
                    user_masteruser_email_id = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    form_id = table.Column<int>(type: "int", nullable: false),
                    forms_masterform_id = table.Column<int>(type: "int", nullable: true),
                    form_list_order = table.Column<int>(type: "int", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_recently_accessed_screens_forms_master_forms_masterform_id",
                        column: x => x.forms_masterform_id,
                        principalTable: "forms_master",
                        principalColumn: "form_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_recently_accessed_screens_user_master_user_masteruser_email_id",
                        column: x => x.user_masteruser_email_id,
                        principalTable: "user_master",
                        principalColumn: "user_email_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_group_metrix",
                columns: table => new
                {
                    user_email_id = table.Column<int>(type: "int", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    group_id = table.Column<int>(type: "int", nullable: false),
                    user_masteruser_email_id = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    role_masterrole_id = table.Column<int>(type: "int", nullable: true),
                    group_mastergroup_id = table.Column<int>(type: "int", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_user_group_metrix_group_master_group_mastergroup_id",
                        column: x => x.group_mastergroup_id,
                        principalTable: "group_master",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_group_metrix_role_master_role_masterrole_id",
                        column: x => x.role_masterrole_id,
                        principalTable: "role_master",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_group_metrix_user_master_user_masteruser_email_id",
                        column: x => x.user_masteruser_email_id,
                        principalTable: "user_master",
                        principalColumn: "user_email_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_login_fail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_email_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_masteruser_email_id = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    loginat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ip_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_login_fail", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_login_fail_user_master_user_masteruser_email_id",
                        column: x => x.user_masteruser_email_id,
                        principalTable: "user_master",
                        principalColumn: "user_email_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_login_log",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_email_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_masteruser_email_id = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    loginat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ip_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_login_log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_login_log_user_master_user_masteruser_email_id",
                        column: x => x.user_masteruser_email_id,
                        principalTable: "user_master",
                        principalColumn: "user_email_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "project_master",
                columns: table => new
                {
                    project_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    project_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    project_desc = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    project_type_id = table.Column<int>(type: "int", nullable: false),
                    project_type_id1 = table.Column<int>(type: "int", nullable: true),
                    project_scope_id = table.Column<int>(type: "int", nullable: false),
                    project_scope_id1 = table.Column<int>(type: "int", nullable: true),
                    project_size = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    project_year = table.Column<int>(type: "int", nullable: false),
                    project_start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    project_end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    currency_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    currency_mastercurrency_code = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    country_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    country_mastercountry_code = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    business_unit_id = table.Column<int>(type: "int", nullable: false),
                    business_unit_id1 = table.Column<int>(type: "int", nullable: true),
                    site_id = table.Column<int>(type: "int", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_master", x => x.project_id);
                    table.ForeignKey(
                        name: "FK_project_master_business_unit_master_business_unit_id1",
                        column: x => x.business_unit_id1,
                        principalTable: "business_unit_master",
                        principalColumn: "business_unit_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_project_master_country_master_country_mastercountry_code",
                        column: x => x.country_mastercountry_code,
                        principalTable: "country_master",
                        principalColumn: "country_code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_project_master_currency_master_currency_mastercurrency_code",
                        column: x => x.currency_mastercurrency_code,
                        principalTable: "currency_master",
                        principalColumn: "currency_code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_project_master_project_scope_master_project_scope_id1",
                        column: x => x.project_scope_id1,
                        principalTable: "project_scope_master",
                        principalColumn: "project_scope_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_project_master_project_type_master_project_type_id1",
                        column: x => x.project_type_id1,
                        principalTable: "project_type_master",
                        principalColumn: "project_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_project_master_site_master_site_id",
                        column: x => x.site_id,
                        principalTable: "site_master",
                        principalColumn: "site_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pdc_project_element_data",
                columns: table => new
                {
                    header_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pdc_header_dataheader_Id = table.Column<int>(type: "int", nullable: true),
                    elementelement_id = table.Column<int>(type: "int", nullable: false),
                    modal_type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    quantity = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    total_service_hours = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    unit_cost = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    share_in_total = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    scope_commmentary = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pdc_project_element_data", x => x.header_Id);
                    table.ForeignKey(
                        name: "FK_pdc_project_element_data_pdc_header_data_pdc_header_dataheader_Id",
                        column: x => x.pdc_header_dataheader_Id,
                        principalTable: "pdc_header_data",
                        principalColumn: "header_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_country_master_continent_mastercontinent_code",
                table: "country_master",
                column: "continent_mastercontinent_code");

            migrationBuilder.CreateIndex(
                name: "IX_currency_master_country_mastercountry_code",
                table: "currency_master",
                column: "country_mastercountry_code");

            migrationBuilder.CreateIndex(
                name: "IX_forms_master_module_mastermodule_id",
                table: "forms_master",
                column: "module_mastermodule_id");

            migrationBuilder.CreateIndex(
                name: "IX_group_master_group_type_id1",
                table: "group_master",
                column: "group_type_id1");

            migrationBuilder.CreateIndex(
                name: "IX_name_value_pair_field_masterfield_id",
                table: "name_value_pair",
                column: "field_masterfield_id");

            migrationBuilder.CreateIndex(
                name: "IX_pdc_element_master_pdc_category_mastercategory_id",
                table: "pdc_element_master",
                column: "pdc_category_mastercategory_id");

            migrationBuilder.CreateIndex(
                name: "IX_pdc_form_category_matrix_forms_masterform_id",
                table: "pdc_form_category_matrix",
                column: "forms_masterform_id");

            migrationBuilder.CreateIndex(
                name: "IX_pdc_form_category_matrix_pdc_category_mastercategory_id",
                table: "pdc_form_category_matrix",
                column: "pdc_category_mastercategory_id");

            migrationBuilder.CreateIndex(
                name: "IX_pdc_header_data_forms_masterform_id",
                table: "pdc_header_data",
                column: "forms_masterform_id");

            migrationBuilder.CreateIndex(
                name: "IX_pdc_project_element_data_pdc_header_dataheader_Id",
                table: "pdc_project_element_data",
                column: "pdc_header_dataheader_Id");

            migrationBuilder.CreateIndex(
                name: "IX_pending_groups_mails_pending_Groupspending_group_ID",
                table: "pending_groups_mails",
                column: "pending_Groupspending_group_ID");

            migrationBuilder.CreateIndex(
                name: "IX_project_master_business_unit_id1",
                table: "project_master",
                column: "business_unit_id1");

            migrationBuilder.CreateIndex(
                name: "IX_project_master_country_mastercountry_code",
                table: "project_master",
                column: "country_mastercountry_code");

            migrationBuilder.CreateIndex(
                name: "IX_project_master_currency_mastercurrency_code",
                table: "project_master",
                column: "currency_mastercurrency_code");

            migrationBuilder.CreateIndex(
                name: "IX_project_master_project_scope_id1",
                table: "project_master",
                column: "project_scope_id1");

            migrationBuilder.CreateIndex(
                name: "IX_project_master_project_type_id1",
                table: "project_master",
                column: "project_type_id1");

            migrationBuilder.CreateIndex(
                name: "IX_project_master_site_id",
                table: "project_master",
                column: "site_id");

            migrationBuilder.CreateIndex(
                name: "IX_quick_access_screens_forms_masterform_id",
                table: "quick_access_screens",
                column: "forms_masterform_id");

            migrationBuilder.CreateIndex(
                name: "IX_quick_access_screens_user_masteruser_email_id",
                table: "quick_access_screens",
                column: "user_masteruser_email_id");

            migrationBuilder.CreateIndex(
                name: "IX_recently_accessed_screens_forms_masterform_id",
                table: "recently_accessed_screens",
                column: "forms_masterform_id");

            migrationBuilder.CreateIndex(
                name: "IX_recently_accessed_screens_user_masteruser_email_id",
                table: "recently_accessed_screens",
                column: "user_masteruser_email_id");

            migrationBuilder.CreateIndex(
                name: "IX_site_master_country_mastercountry_code",
                table: "site_master",
                column: "country_mastercountry_code");

            migrationBuilder.CreateIndex(
                name: "IX_user_group_metrix_group_mastergroup_id",
                table: "user_group_metrix",
                column: "group_mastergroup_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_group_metrix_role_masterrole_id",
                table: "user_group_metrix",
                column: "role_masterrole_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_group_metrix_user_masteruser_email_id",
                table: "user_group_metrix",
                column: "user_masteruser_email_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_login_fail_user_masteruser_email_id",
                table: "user_login_fail",
                column: "user_masteruser_email_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_login_log_user_masteruser_email_id",
                table: "user_login_log",
                column: "user_masteruser_email_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_master_user_type_masteruser_type_id",
                table: "user_master",
                column: "user_type_masteruser_type_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "currency_conversion");

            migrationBuilder.DropTable(
                name: "dynamic_form_data");

            migrationBuilder.DropTable(
                name: "form_field_matrix");

            migrationBuilder.DropTable(
                name: "group_form_access_matrix");

            migrationBuilder.DropTable(
                name: "name_value_pair");

            migrationBuilder.DropTable(
                name: "pdc_element_master");

            migrationBuilder.DropTable(
                name: "pdc_form_category_matrix");

            migrationBuilder.DropTable(
                name: "pdc_project_element_data");

            migrationBuilder.DropTable(
                name: "pending_groups_mails");

            migrationBuilder.DropTable(
                name: "project_master");

            migrationBuilder.DropTable(
                name: "project_phase_master");

            migrationBuilder.DropTable(
                name: "quick_access_screens");

            migrationBuilder.DropTable(
                name: "recently_accessed_screens");

            migrationBuilder.DropTable(
                name: "user_group_metrix");

            migrationBuilder.DropTable(
                name: "user_login_fail");

            migrationBuilder.DropTable(
                name: "user_login_log");

            migrationBuilder.DropTable(
                name: "field_master");

            migrationBuilder.DropTable(
                name: "pdc_category_master");

            migrationBuilder.DropTable(
                name: "pdc_header_data");

            migrationBuilder.DropTable(
                name: "pending_groups");

            migrationBuilder.DropTable(
                name: "business_unit_master");

            migrationBuilder.DropTable(
                name: "currency_master");

            migrationBuilder.DropTable(
                name: "project_scope_master");

            migrationBuilder.DropTable(
                name: "project_type_master");

            migrationBuilder.DropTable(
                name: "site_master");

            migrationBuilder.DropTable(
                name: "group_master");

            migrationBuilder.DropTable(
                name: "role_master");

            migrationBuilder.DropTable(
                name: "user_master");

            migrationBuilder.DropTable(
                name: "forms_master");

            migrationBuilder.DropTable(
                name: "country_master");

            migrationBuilder.DropTable(
                name: "group_type_master");

            migrationBuilder.DropTable(
                name: "user_type_master");

            migrationBuilder.DropTable(
                name: "module_master");

            migrationBuilder.DropTable(
                name: "continent_master");
        }
    }
}
