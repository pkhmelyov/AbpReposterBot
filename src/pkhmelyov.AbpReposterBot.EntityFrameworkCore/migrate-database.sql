CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);


DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE TABLE "AbpAuditLogs" (
        "Id" bigserial NOT NULL,
        "TenantId" integer NULL,
        "UserId" bigint NULL,
        "ServiceName" character varying(256) NULL,
        "MethodName" character varying(256) NULL,
        "Parameters" character varying(1024) NULL,
        "ReturnValue" text NULL,
        "ExecutionTime" timestamp without time zone NOT NULL,
        "ExecutionDuration" integer NOT NULL,
        "ClientIpAddress" character varying(64) NULL,
        "ClientName" character varying(128) NULL,
        "BrowserInfo" character varying(512) NULL,
        "Exception" character varying(2000) NULL,
        "ImpersonatorUserId" bigint NULL,
        "ImpersonatorTenantId" integer NULL,
        "CustomData" character varying(2000) NULL,
        CONSTRAINT "PK_AbpAuditLogs" PRIMARY KEY ("Id")
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE TABLE "AbpBackgroundJobs" (
        "Id" bigserial NOT NULL,
        "CreationTime" timestamp without time zone NOT NULL,
        "CreatorUserId" bigint NULL,
        "JobType" character varying(512) NOT NULL,
        "JobArgs" character varying(1048576) NOT NULL,
        "TryCount" smallint NOT NULL,
        "NextTryTime" timestamp without time zone NOT NULL,
        "LastTryTime" timestamp without time zone NULL,
        "IsAbandoned" boolean NOT NULL,
        "Priority" smallint NOT NULL,
        CONSTRAINT "PK_AbpBackgroundJobs" PRIMARY KEY ("Id")
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE TABLE "AbpEditions" (
        "Id" serial NOT NULL,
        "CreationTime" timestamp without time zone NOT NULL,
        "CreatorUserId" bigint NULL,
        "LastModificationTime" timestamp without time zone NULL,
        "LastModifierUserId" bigint NULL,
        "IsDeleted" boolean NOT NULL,
        "DeleterUserId" bigint NULL,
        "DeletionTime" timestamp without time zone NULL,
        "Name" character varying(32) NOT NULL,
        "DisplayName" character varying(64) NOT NULL,
        CONSTRAINT "PK_AbpEditions" PRIMARY KEY ("Id")
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE TABLE "AbpEntityChangeSets" (
        "Id" bigserial NOT NULL,
        "BrowserInfo" character varying(512) NULL,
        "ClientIpAddress" character varying(64) NULL,
        "ClientName" character varying(128) NULL,
        "CreationTime" timestamp without time zone NOT NULL,
        "ExtensionData" text NULL,
        "ImpersonatorTenantId" integer NULL,
        "ImpersonatorUserId" bigint NULL,
        "Reason" character varying(256) NULL,
        "TenantId" integer NULL,
        "UserId" bigint NULL,
        CONSTRAINT "PK_AbpEntityChangeSets" PRIMARY KEY ("Id")
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE TABLE "AbpLanguages" (
        "Id" serial NOT NULL,
        "CreationTime" timestamp without time zone NOT NULL,
        "CreatorUserId" bigint NULL,
        "LastModificationTime" timestamp without time zone NULL,
        "LastModifierUserId" bigint NULL,
        "IsDeleted" boolean NOT NULL,
        "DeleterUserId" bigint NULL,
        "DeletionTime" timestamp without time zone NULL,
        "TenantId" integer NULL,
        "Name" character varying(128) NOT NULL,
        "DisplayName" character varying(64) NOT NULL,
        "Icon" character varying(128) NULL,
        "IsDisabled" boolean NOT NULL,
        CONSTRAINT "PK_AbpLanguages" PRIMARY KEY ("Id")
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE TABLE "AbpLanguageTexts" (
        "Id" bigserial NOT NULL,
        "CreationTime" timestamp without time zone NOT NULL,
        "CreatorUserId" bigint NULL,
        "LastModificationTime" timestamp without time zone NULL,
        "LastModifierUserId" bigint NULL,
        "TenantId" integer NULL,
        "LanguageName" character varying(128) NOT NULL,
        "Source" character varying(128) NOT NULL,
        "Key" character varying(256) NOT NULL,
        "Value" text NOT NULL,
        CONSTRAINT "PK_AbpLanguageTexts" PRIMARY KEY ("Id")
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE TABLE "AbpNotifications" (
        "Id" uuid NOT NULL,
        "CreationTime" timestamp without time zone NOT NULL,
        "CreatorUserId" bigint NULL,
        "NotificationName" character varying(96) NOT NULL,
        "Data" character varying(1048576) NULL,
        "DataTypeName" character varying(512) NULL,
        "EntityTypeName" character varying(250) NULL,
        "EntityTypeAssemblyQualifiedName" character varying(512) NULL,
        "EntityId" character varying(96) NULL,
        "Severity" smallint NOT NULL,
        "UserIds" character varying(131072) NULL,
        "ExcludedUserIds" character varying(131072) NULL,
        "TenantIds" character varying(131072) NULL,
        CONSTRAINT "PK_AbpNotifications" PRIMARY KEY ("Id")
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE TABLE "AbpNotificationSubscriptions" (
        "Id" uuid NOT NULL,
        "CreationTime" timestamp without time zone NOT NULL,
        "CreatorUserId" bigint NULL,
        "TenantId" integer NULL,
        "UserId" bigint NOT NULL,
        "NotificationName" character varying(96) NULL,
        "EntityTypeName" character varying(250) NULL,
        "EntityTypeAssemblyQualifiedName" character varying(512) NULL,
        "EntityId" character varying(96) NULL,
        CONSTRAINT "PK_AbpNotificationSubscriptions" PRIMARY KEY ("Id")
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE TABLE "AbpOrganizationUnitRoles" (
        "Id" bigserial NOT NULL,
        "CreationTime" timestamp without time zone NOT NULL,
        "CreatorUserId" bigint NULL,
        "TenantId" integer NULL,
        "RoleId" integer NOT NULL,
        "OrganizationUnitId" bigint NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_AbpOrganizationUnitRoles" PRIMARY KEY ("Id")
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE TABLE "AbpOrganizationUnits" (
        "Id" bigserial NOT NULL,
        "CreationTime" timestamp without time zone NOT NULL,
        "CreatorUserId" bigint NULL,
        "LastModificationTime" timestamp without time zone NULL,
        "LastModifierUserId" bigint NULL,
        "IsDeleted" boolean NOT NULL,
        "DeleterUserId" bigint NULL,
        "DeletionTime" timestamp without time zone NULL,
        "TenantId" integer NULL,
        "ParentId" bigint NULL,
        "Code" character varying(95) NOT NULL,
        "DisplayName" character varying(128) NOT NULL,
        CONSTRAINT "PK_AbpOrganizationUnits" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_AbpOrganizationUnits_AbpOrganizationUnits_ParentId" FOREIGN KEY ("ParentId") REFERENCES "AbpOrganizationUnits" ("Id") ON DELETE RESTRICT
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE TABLE "AbpTenantNotifications" (
        "Id" uuid NOT NULL,
        "CreationTime" timestamp without time zone NOT NULL,
        "CreatorUserId" bigint NULL,
        "TenantId" integer NULL,
        "NotificationName" character varying(96) NOT NULL,
        "Data" character varying(1048576) NULL,
        "DataTypeName" character varying(512) NULL,
        "EntityTypeName" character varying(250) NULL,
        "EntityTypeAssemblyQualifiedName" character varying(512) NULL,
        "EntityId" character varying(96) NULL,
        "Severity" smallint NOT NULL,
        CONSTRAINT "PK_AbpTenantNotifications" PRIMARY KEY ("Id")
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE TABLE "AbpUserAccounts" (
        "Id" bigserial NOT NULL,
        "CreationTime" timestamp without time zone NOT NULL,
        "CreatorUserId" bigint NULL,
        "LastModificationTime" timestamp without time zone NULL,
        "LastModifierUserId" bigint NULL,
        "IsDeleted" boolean NOT NULL,
        "DeleterUserId" bigint NULL,
        "DeletionTime" timestamp without time zone NULL,
        "TenantId" integer NULL,
        "UserId" bigint NOT NULL,
        "UserLinkId" bigint NULL,
        "UserName" character varying(256) NULL,
        "EmailAddress" character varying(256) NULL,
        CONSTRAINT "PK_AbpUserAccounts" PRIMARY KEY ("Id")
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE TABLE "AbpUserLoginAttempts" (
        "Id" bigserial NOT NULL,
        "TenantId" integer NULL,
        "TenancyName" character varying(64) NULL,
        "UserId" bigint NULL,
        "UserNameOrEmailAddress" character varying(255) NULL,
        "ClientIpAddress" character varying(64) NULL,
        "ClientName" character varying(128) NULL,
        "BrowserInfo" character varying(512) NULL,
        "Result" smallint NOT NULL,
        "CreationTime" timestamp without time zone NOT NULL,
        CONSTRAINT "PK_AbpUserLoginAttempts" PRIMARY KEY ("Id")
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE TABLE "AbpUserNotifications" (
        "Id" uuid NOT NULL,
        "TenantId" integer NULL,
        "UserId" bigint NOT NULL,
        "TenantNotificationId" uuid NOT NULL,
        "State" integer NOT NULL,
        "CreationTime" timestamp without time zone NOT NULL,
        CONSTRAINT "PK_AbpUserNotifications" PRIMARY KEY ("Id")
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE TABLE "AbpUserOrganizationUnits" (
        "Id" bigserial NOT NULL,
        "CreationTime" timestamp without time zone NOT NULL,
        "CreatorUserId" bigint NULL,
        "TenantId" integer NULL,
        "UserId" bigint NOT NULL,
        "OrganizationUnitId" bigint NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_AbpUserOrganizationUnits" PRIMARY KEY ("Id")
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE TABLE "AbpUsers" (
        "Id" bigserial NOT NULL,
        "CreationTime" timestamp without time zone NOT NULL,
        "CreatorUserId" bigint NULL,
        "LastModificationTime" timestamp without time zone NULL,
        "LastModifierUserId" bigint NULL,
        "IsDeleted" boolean NOT NULL,
        "DeleterUserId" bigint NULL,
        "DeletionTime" timestamp without time zone NULL,
        "AuthenticationSource" character varying(64) NULL,
        "UserName" character varying(256) NOT NULL,
        "TenantId" integer NULL,
        "EmailAddress" character varying(256) NOT NULL,
        "Name" character varying(64) NOT NULL,
        "Surname" character varying(64) NOT NULL,
        "Password" character varying(128) NOT NULL,
        "EmailConfirmationCode" character varying(328) NULL,
        "PasswordResetCode" character varying(328) NULL,
        "LockoutEndDateUtc" timestamp without time zone NULL,
        "AccessFailedCount" integer NOT NULL,
        "IsLockoutEnabled" boolean NOT NULL,
        "PhoneNumber" character varying(32) NULL,
        "IsPhoneNumberConfirmed" boolean NOT NULL,
        "SecurityStamp" character varying(128) NULL,
        "IsTwoFactorEnabled" boolean NOT NULL,
        "IsEmailConfirmed" boolean NOT NULL,
        "IsActive" boolean NOT NULL,
        "NormalizedUserName" character varying(256) NOT NULL,
        "NormalizedEmailAddress" character varying(256) NOT NULL,
        "ConcurrencyStamp" character varying(128) NULL,
        CONSTRAINT "PK_AbpUsers" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_AbpUsers_AbpUsers_CreatorUserId" FOREIGN KEY ("CreatorUserId") REFERENCES "AbpUsers" ("Id") ON DELETE RESTRICT,
        CONSTRAINT "FK_AbpUsers_AbpUsers_DeleterUserId" FOREIGN KEY ("DeleterUserId") REFERENCES "AbpUsers" ("Id") ON DELETE RESTRICT,
        CONSTRAINT "FK_AbpUsers_AbpUsers_LastModifierUserId" FOREIGN KEY ("LastModifierUserId") REFERENCES "AbpUsers" ("Id") ON DELETE RESTRICT
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE TABLE "AbpFeatures" (
        "Id" bigserial NOT NULL,
        "CreationTime" timestamp without time zone NOT NULL,
        "CreatorUserId" bigint NULL,
        "TenantId" integer NULL,
        "Name" character varying(128) NOT NULL,
        "Value" character varying(2000) NOT NULL,
        "Discriminator" text NOT NULL,
        "EditionId" integer NULL,
        CONSTRAINT "PK_AbpFeatures" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_AbpFeatures_AbpEditions_EditionId" FOREIGN KEY ("EditionId") REFERENCES "AbpEditions" ("Id") ON DELETE CASCADE
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE TABLE "AbpEntityChanges" (
        "Id" bigserial NOT NULL,
        "ChangeTime" timestamp without time zone NOT NULL,
        "ChangeType" smallint NOT NULL,
        "EntityChangeSetId" bigint NOT NULL,
        "EntityId" character varying(48) NULL,
        "EntityTypeFullName" character varying(192) NULL,
        "TenantId" integer NULL,
        CONSTRAINT "PK_AbpEntityChanges" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_AbpEntityChanges_AbpEntityChangeSets_EntityChangeSetId" FOREIGN KEY ("EntityChangeSetId") REFERENCES "AbpEntityChangeSets" ("Id") ON DELETE CASCADE
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE TABLE "AbpRoles" (
        "Id" serial NOT NULL,
        "CreationTime" timestamp without time zone NOT NULL,
        "CreatorUserId" bigint NULL,
        "LastModificationTime" timestamp without time zone NULL,
        "LastModifierUserId" bigint NULL,
        "IsDeleted" boolean NOT NULL,
        "DeleterUserId" bigint NULL,
        "DeletionTime" timestamp without time zone NULL,
        "TenantId" integer NULL,
        "Name" character varying(32) NOT NULL,
        "DisplayName" character varying(64) NOT NULL,
        "IsStatic" boolean NOT NULL,
        "IsDefault" boolean NOT NULL,
        "NormalizedName" character varying(32) NOT NULL,
        "ConcurrencyStamp" character varying(128) NULL,
        "Description" character varying(5000) NULL,
        CONSTRAINT "PK_AbpRoles" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_AbpRoles_AbpUsers_CreatorUserId" FOREIGN KEY ("CreatorUserId") REFERENCES "AbpUsers" ("Id") ON DELETE RESTRICT,
        CONSTRAINT "FK_AbpRoles_AbpUsers_DeleterUserId" FOREIGN KEY ("DeleterUserId") REFERENCES "AbpUsers" ("Id") ON DELETE RESTRICT,
        CONSTRAINT "FK_AbpRoles_AbpUsers_LastModifierUserId" FOREIGN KEY ("LastModifierUserId") REFERENCES "AbpUsers" ("Id") ON DELETE RESTRICT
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE TABLE "AbpSettings" (
        "Id" bigserial NOT NULL,
        "CreationTime" timestamp without time zone NOT NULL,
        "CreatorUserId" bigint NULL,
        "LastModificationTime" timestamp without time zone NULL,
        "LastModifierUserId" bigint NULL,
        "TenantId" integer NULL,
        "UserId" bigint NULL,
        "Name" character varying(256) NOT NULL,
        "Value" character varying(2000) NULL,
        CONSTRAINT "PK_AbpSettings" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_AbpSettings_AbpUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AbpUsers" ("Id") ON DELETE RESTRICT
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE TABLE "AbpTenants" (
        "Id" serial NOT NULL,
        "CreationTime" timestamp without time zone NOT NULL,
        "CreatorUserId" bigint NULL,
        "LastModificationTime" timestamp without time zone NULL,
        "LastModifierUserId" bigint NULL,
        "IsDeleted" boolean NOT NULL,
        "DeleterUserId" bigint NULL,
        "DeletionTime" timestamp without time zone NULL,
        "TenancyName" character varying(64) NOT NULL,
        "Name" character varying(128) NOT NULL,
        "ConnectionString" character varying(1024) NULL,
        "IsActive" boolean NOT NULL,
        "EditionId" integer NULL,
        CONSTRAINT "PK_AbpTenants" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_AbpTenants_AbpUsers_CreatorUserId" FOREIGN KEY ("CreatorUserId") REFERENCES "AbpUsers" ("Id") ON DELETE RESTRICT,
        CONSTRAINT "FK_AbpTenants_AbpUsers_DeleterUserId" FOREIGN KEY ("DeleterUserId") REFERENCES "AbpUsers" ("Id") ON DELETE RESTRICT,
        CONSTRAINT "FK_AbpTenants_AbpEditions_EditionId" FOREIGN KEY ("EditionId") REFERENCES "AbpEditions" ("Id") ON DELETE RESTRICT,
        CONSTRAINT "FK_AbpTenants_AbpUsers_LastModifierUserId" FOREIGN KEY ("LastModifierUserId") REFERENCES "AbpUsers" ("Id") ON DELETE RESTRICT
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE TABLE "AbpUserClaims" (
        "Id" bigserial NOT NULL,
        "CreationTime" timestamp without time zone NOT NULL,
        "CreatorUserId" bigint NULL,
        "TenantId" integer NULL,
        "UserId" bigint NOT NULL,
        "ClaimType" character varying(256) NULL,
        "ClaimValue" text NULL,
        CONSTRAINT "PK_AbpUserClaims" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_AbpUserClaims_AbpUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AbpUsers" ("Id") ON DELETE CASCADE
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE TABLE "AbpUserLogins" (
        "Id" bigserial NOT NULL,
        "TenantId" integer NULL,
        "UserId" bigint NOT NULL,
        "LoginProvider" character varying(128) NOT NULL,
        "ProviderKey" character varying(256) NOT NULL,
        CONSTRAINT "PK_AbpUserLogins" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_AbpUserLogins_AbpUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AbpUsers" ("Id") ON DELETE CASCADE
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE TABLE "AbpUserRoles" (
        "Id" bigserial NOT NULL,
        "CreationTime" timestamp without time zone NOT NULL,
        "CreatorUserId" bigint NULL,
        "TenantId" integer NULL,
        "UserId" bigint NOT NULL,
        "RoleId" integer NOT NULL,
        CONSTRAINT "PK_AbpUserRoles" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_AbpUserRoles_AbpUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AbpUsers" ("Id") ON DELETE CASCADE
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE TABLE "AbpUserTokens" (
        "Id" bigserial NOT NULL,
        "TenantId" integer NULL,
        "UserId" bigint NOT NULL,
        "LoginProvider" character varying(128) NULL,
        "Name" character varying(128) NULL,
        "Value" character varying(512) NULL,
        "ExpireDate" timestamp without time zone NULL,
        CONSTRAINT "PK_AbpUserTokens" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_AbpUserTokens_AbpUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AbpUsers" ("Id") ON DELETE CASCADE
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE TABLE "AbpEntityPropertyChanges" (
        "Id" bigserial NOT NULL,
        "EntityChangeId" bigint NOT NULL,
        "NewValue" character varying(512) NULL,
        "OriginalValue" character varying(512) NULL,
        "PropertyName" character varying(96) NULL,
        "PropertyTypeFullName" character varying(192) NULL,
        "TenantId" integer NULL,
        CONSTRAINT "PK_AbpEntityPropertyChanges" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_AbpEntityPropertyChanges_AbpEntityChanges_EntityChangeId" FOREIGN KEY ("EntityChangeId") REFERENCES "AbpEntityChanges" ("Id") ON DELETE CASCADE
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE TABLE "AbpPermissions" (
        "Id" bigserial NOT NULL,
        "CreationTime" timestamp without time zone NOT NULL,
        "CreatorUserId" bigint NULL,
        "TenantId" integer NULL,
        "Name" character varying(128) NOT NULL,
        "IsGranted" boolean NOT NULL,
        "Discriminator" text NOT NULL,
        "RoleId" integer NULL,
        "UserId" bigint NULL,
        CONSTRAINT "PK_AbpPermissions" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_AbpPermissions_AbpRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AbpRoles" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_AbpPermissions_AbpUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AbpUsers" ("Id") ON DELETE CASCADE
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE TABLE "AbpRoleClaims" (
        "Id" bigserial NOT NULL,
        "CreationTime" timestamp without time zone NOT NULL,
        "CreatorUserId" bigint NULL,
        "TenantId" integer NULL,
        "RoleId" integer NOT NULL,
        "ClaimType" character varying(256) NULL,
        "ClaimValue" text NULL,
        CONSTRAINT "PK_AbpRoleClaims" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_AbpRoleClaims_AbpRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AbpRoles" ("Id") ON DELETE CASCADE
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpAuditLogs_TenantId_ExecutionDuration" ON "AbpAuditLogs" ("TenantId", "ExecutionDuration");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpAuditLogs_TenantId_ExecutionTime" ON "AbpAuditLogs" ("TenantId", "ExecutionTime");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpAuditLogs_TenantId_UserId" ON "AbpAuditLogs" ("TenantId", "UserId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpBackgroundJobs_IsAbandoned_NextTryTime" ON "AbpBackgroundJobs" ("IsAbandoned", "NextTryTime");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpEntityChanges_EntityChangeSetId" ON "AbpEntityChanges" ("EntityChangeSetId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpEntityChanges_EntityTypeFullName_EntityId" ON "AbpEntityChanges" ("EntityTypeFullName", "EntityId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpEntityChangeSets_TenantId_CreationTime" ON "AbpEntityChangeSets" ("TenantId", "CreationTime");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpEntityChangeSets_TenantId_Reason" ON "AbpEntityChangeSets" ("TenantId", "Reason");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpEntityChangeSets_TenantId_UserId" ON "AbpEntityChangeSets" ("TenantId", "UserId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpEntityPropertyChanges_EntityChangeId" ON "AbpEntityPropertyChanges" ("EntityChangeId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpFeatures_EditionId_Name" ON "AbpFeatures" ("EditionId", "Name");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpFeatures_TenantId_Name" ON "AbpFeatures" ("TenantId", "Name");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpLanguages_TenantId_Name" ON "AbpLanguages" ("TenantId", "Name");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpLanguageTexts_TenantId_Source_LanguageName_Key" ON "AbpLanguageTexts" ("TenantId", "Source", "LanguageName", "Key");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpNotificationSubscriptions_NotificationName_EntityTypeNam~" ON "AbpNotificationSubscriptions" ("NotificationName", "EntityTypeName", "EntityId", "UserId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpNotificationSubscriptions_TenantId_NotificationName_Enti~" ON "AbpNotificationSubscriptions" ("TenantId", "NotificationName", "EntityTypeName", "EntityId", "UserId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpOrganizationUnitRoles_TenantId_OrganizationUnitId" ON "AbpOrganizationUnitRoles" ("TenantId", "OrganizationUnitId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpOrganizationUnitRoles_TenantId_RoleId" ON "AbpOrganizationUnitRoles" ("TenantId", "RoleId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpOrganizationUnits_ParentId" ON "AbpOrganizationUnits" ("ParentId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpOrganizationUnits_TenantId_Code" ON "AbpOrganizationUnits" ("TenantId", "Code");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpPermissions_TenantId_Name" ON "AbpPermissions" ("TenantId", "Name");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpPermissions_RoleId" ON "AbpPermissions" ("RoleId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpPermissions_UserId" ON "AbpPermissions" ("UserId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpRoleClaims_RoleId" ON "AbpRoleClaims" ("RoleId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpRoleClaims_TenantId_ClaimType" ON "AbpRoleClaims" ("TenantId", "ClaimType");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpRoles_CreatorUserId" ON "AbpRoles" ("CreatorUserId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpRoles_DeleterUserId" ON "AbpRoles" ("DeleterUserId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpRoles_LastModifierUserId" ON "AbpRoles" ("LastModifierUserId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpRoles_TenantId_NormalizedName" ON "AbpRoles" ("TenantId", "NormalizedName");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpSettings_UserId" ON "AbpSettings" ("UserId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE UNIQUE INDEX "IX_AbpSettings_TenantId_Name_UserId" ON "AbpSettings" ("TenantId", "Name", "UserId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpTenantNotifications_TenantId" ON "AbpTenantNotifications" ("TenantId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpTenants_CreatorUserId" ON "AbpTenants" ("CreatorUserId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpTenants_DeleterUserId" ON "AbpTenants" ("DeleterUserId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpTenants_EditionId" ON "AbpTenants" ("EditionId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpTenants_LastModifierUserId" ON "AbpTenants" ("LastModifierUserId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpTenants_TenancyName" ON "AbpTenants" ("TenancyName");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpUserAccounts_EmailAddress" ON "AbpUserAccounts" ("EmailAddress");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpUserAccounts_UserName" ON "AbpUserAccounts" ("UserName");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpUserAccounts_TenantId_EmailAddress" ON "AbpUserAccounts" ("TenantId", "EmailAddress");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpUserAccounts_TenantId_UserId" ON "AbpUserAccounts" ("TenantId", "UserId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpUserAccounts_TenantId_UserName" ON "AbpUserAccounts" ("TenantId", "UserName");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpUserClaims_UserId" ON "AbpUserClaims" ("UserId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpUserClaims_TenantId_ClaimType" ON "AbpUserClaims" ("TenantId", "ClaimType");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpUserLoginAttempts_UserId_TenantId" ON "AbpUserLoginAttempts" ("UserId", "TenantId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpUserLoginAttempts_TenancyName_UserNameOrEmailAddress_Res~" ON "AbpUserLoginAttempts" ("TenancyName", "UserNameOrEmailAddress", "Result");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpUserLogins_UserId" ON "AbpUserLogins" ("UserId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpUserLogins_TenantId_UserId" ON "AbpUserLogins" ("TenantId", "UserId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpUserLogins_TenantId_LoginProvider_ProviderKey" ON "AbpUserLogins" ("TenantId", "LoginProvider", "ProviderKey");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpUserNotifications_UserId_State_CreationTime" ON "AbpUserNotifications" ("UserId", "State", "CreationTime");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpUserOrganizationUnits_TenantId_OrganizationUnitId" ON "AbpUserOrganizationUnits" ("TenantId", "OrganizationUnitId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpUserOrganizationUnits_TenantId_UserId" ON "AbpUserOrganizationUnits" ("TenantId", "UserId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpUserRoles_UserId" ON "AbpUserRoles" ("UserId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpUserRoles_TenantId_RoleId" ON "AbpUserRoles" ("TenantId", "RoleId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpUserRoles_TenantId_UserId" ON "AbpUserRoles" ("TenantId", "UserId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpUsers_CreatorUserId" ON "AbpUsers" ("CreatorUserId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpUsers_DeleterUserId" ON "AbpUsers" ("DeleterUserId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpUsers_LastModifierUserId" ON "AbpUsers" ("LastModifierUserId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpUsers_TenantId_NormalizedEmailAddress" ON "AbpUsers" ("TenantId", "NormalizedEmailAddress");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpUsers_TenantId_NormalizedUserName" ON "AbpUsers" ("TenantId", "NormalizedUserName");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpUserTokens_UserId" ON "AbpUserTokens" ("UserId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    CREATE INDEX "IX_AbpUserTokens_TenantId_UserId" ON "AbpUserTokens" ("TenantId", "UserId");
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190806200143_Initial') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20190806200143_Initial', '2.2.4-servicing-10062');
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190808174122_AddedPosts') THEN
    CREATE TABLE "Posts" (
        "Id" serial NOT NULL,
        "CreationTime" timestamp without time zone NOT NULL,
        "CreatorUserId" bigint NULL,
        "LastModificationTime" timestamp without time zone NULL,
        "LastModifierUserId" bigint NULL,
        "IsDeleted" boolean NOT NULL,
        "DeleterUserId" bigint NULL,
        "DeletionTime" timestamp without time zone NULL,
        "IsActive" boolean NOT NULL,
        "Body" text NULL,
        CONSTRAINT "PK_Posts" PRIMARY KEY ("Id")
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20190808174122_AddedPosts') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20190808174122_AddedPosts', '2.2.4-servicing-10062');
    END IF;
END $$;
