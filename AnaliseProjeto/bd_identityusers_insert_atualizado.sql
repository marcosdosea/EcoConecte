##### ROLES INSERT #####

INSERT INTO `identityusers`.`aspnetroles` (`Id`, `Name`, `NormalizedName`) VALUES ('1', 'ADMROOT', 'ADMROOT');
INSERT INTO `identityusers`.`aspnetroles` (`Id`, `Name`, `NormalizedName`) VALUES ('2', 'COOPERADO', 'COOPERADO');
INSERT INTO `identityusers`.`aspnetroles` (`Id`, `Name`, `NormalizedName`) VALUES ('3', 'USERDEFAULT', 'USERDEFAULT');

##### USER SIS INSERT #####

INSERT INTO `aspnetusers` (`Id`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`) VALUES ('a1e3cff1-f94b-448d-8404-2cedd56f0e91', 'adm@ecoconecte.com.br', 'ADM@ECOCONECTE.COM.BR', 'adm@ecoconecte.com.br', 'ADM@ECOCONECTE.COM.BR', '0', 'AQAAAAIAAYagAAAAEJqh2c8v/WUfHVoQ9TMMg61KWL4Ilp9GNLH54Hg7NvArsqK6AczaFqDi10ULNxjKDw==', '2XJIF3AJXXV4WN4HHIMKOQKAUIGZM4DC', '501ede52-cf99-4b81-827d-fc85264095cd', NULL, '0', '0', NULL, '1', '0');
INSERT INTO `aspnetusers` (`Id`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`) VALUES ('0ef4f86b-746a-41d2-859f-6218f658a08f', 'cooperado@ecoconecte.com.br', 'COOPERADO@ECOCONECTE.COM.BR', 'cooperado@ecoconecte.com.br', 'COOPERADO@ECOCONECTE.COM.BR', '0', 'AQAAAAIAAYagAAAAEAQHlAx9C5ge66ZwomOYZza2RdwMiDISzFC+bPBQQerS550X/hIMwC2Yoh1dcw2/+w==', 'HHJRTAHJVULGMQ6XPYMNU3DS3Y3QDUOI', '2d60e23c-572e-4b80-b25d-a9bc11695da6', NULL, '0', '0', NULL, '1', '0');
INSERT INTO `aspnetusers` (`Id`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`) VALUES ('b1bf753b-30a3-4f59-ac3a-886641a04280', 'usuario@ecoconecte.com.br', 'USUARIO@ECOCONECTE.COM.BR', 'usuario@ecoconecte.com.br', 'USUARIO@ECOCONECTE.COM.BR', '0', 'AQAAAAIAAYagAAAAEJykMvi7UCFl3GrsmnXilMnIMBZKMDZX5ZTDahRKEj/vw0TVAsoTde6Km7YxCuoTSQ==', 'OWJCKKTROY4YG4IVJWVMVJW4LVJ7GDKE', '4de2473b-4a3b-4d1f-972b-7565000f2277', NULL, '0', '0', NULL, '1', '0');

##### USER ROLES INSERT #####

INSERT INTO `aspnetuserroles` (`UserId`, `RoleId`) VALUES ('a1e3cff1-f94b-448d-8404-2cedd56f0e91', '1');
INSERT INTO `aspnetuserroles` (`UserId`, `RoleId`) VALUES ('0ef4f86b-746a-41d2-859f-6218f658a08f', '2');
INSERT INTO `aspnetuserroles` (`UserId`, `RoleId`) VALUES ('b1bf753b-30a3-4f59-ac3a-886641a04280', '3');

