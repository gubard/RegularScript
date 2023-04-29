using Microsoft.EntityFrameworkCore;

using RegularScript.Db.Entities;

namespace RegularScript.Db.Helpers;

public static class SeedHelper
{
    public static void SeedLanguages(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Language>()
            .HasData(
                new Language
                {
                    Id = Guid.Parse("f9a46f4a-0a00-455e-91ce-a809cb5453bc"),
                    CodeIso3 = "aar",
                    Name = "Afar"
                },
                new Language
                {
                    Id = Guid.Parse("df9fde76-1446-4b94-80e8-ca4bbc3187e7"),
                    CodeIso3 = "abk",
                    Name = "Abkhazian"
                },
                new Language
                {
                    Id = Guid.Parse("01c4e8a3-b52a-4db5-b0f8-ee31287c798c"),
                    CodeIso3 = "ace",
                    Name = "Achinese"
                },
                new Language
                {
                    Id = Guid.Parse("8005b159-3567-4f2f-8ac8-2b20c0c7594c"),
                    CodeIso3 = "ach",
                    Name = "Acoli"
                },
                new Language
                {
                    Id = Guid.Parse("cd95db4f-ea7c-4815-a2b2-405d9f1367f3"),
                    CodeIso3 = "ada",
                    Name = "Adangme"
                },
                new Language
                {
                    Id = Guid.Parse("ff249dde-182a-49a0-b4d1-c2e6696dbb35"),
                    CodeIso3 = "ady",
                    Name = "Adygei"
                },
                new Language
                {
                    Id = Guid.Parse("39e15434-4759-443e-9c94-a291846256f5"),
                    CodeIso3 = "afa",
                    Name = "Afro-Asiatic"
                },
                new Language
                {
                    Id = Guid.Parse("10c1cd01-e421-427a-9c47-966b4c3e3833"),
                    CodeIso3 = "afh",
                    Name = "Afrihili"
                },
                new Language
                {
                    Id = Guid.Parse("a1ea309b-645e-43c6-9c0e-55fd4a262d53"),
                    CodeIso3 = "afr",
                    Name = "Afrikaans"
                },
                new Language
                {
                    Id = Guid.Parse("37f09c9b-3de9-488f-bcfe-8b36850a0954"),
                    CodeIso3 = "ain",
                    Name = "Ainu"
                },
                new Language
                {
                    Id = Guid.Parse("7d8d271e-693a-4fab-96c7-5ab1eec8a73a"),
                    CodeIso3 = "aka",
                    Name = "Akan"
                },
                new Language
                {
                    Id = Guid.Parse("575e04eb-22f2-411b-bb7b-762bcf5bb561"),
                    CodeIso3 = "akk",
                    Name = "Akkadian"
                },
                new Language
                {
                    Id = Guid.Parse("bc195f44-db7d-479e-9fa3-16dade66cd1f"),
                    CodeIso3 = "alb",
                    Name = "Albanian"
                },
                new Language
                {
                    Id = Guid.Parse("0d1c131d-3648-46f5-871d-5af3ace2f6cf"),
                    CodeIso3 = "ale",
                    Name = "Aleut"
                },
                new Language
                {
                    Id = Guid.Parse("98851134-86ea-40b5-aa77-8a8bb2386d1c"),
                    CodeIso3 = "alg",
                    Name = "Algonquian"
                },
                new Language
                {
                    Id = Guid.Parse("25be335b-39d1-4ca0-a2a4-d0be9e035042"),
                    CodeIso3 = "alt",
                    Name = "Southern Altai"
                },
                new Language
                {
                    Id = Guid.Parse("aa5e097d-1cf0-4dbf-bab2-745310314637"),
                    CodeIso3 = "amh",
                    Name = "Amharic"
                },
                new Language
                {
                    Id = Guid.Parse("d4c52118-049c-4843-967e-485fac915246"),
                    CodeIso3 = "ang",
                    Name = "English, Old"
                },
                new Language
                {
                    Id = Guid.Parse("5a79041f-980c-4932-b322-33c5ad5f76cc"),
                    CodeIso3 = "anp",
                    Name = "Angika"
                },
                new Language
                {
                    Id = Guid.Parse("c5947c36-b184-4a75-b3bc-4988e6fc8fea"),
                    CodeIso3 = "apa",
                    Name = "Apache"
                },
                new Language
                {
                    Id = Guid.Parse("e869d4ce-ba40-4f01-8f7b-b02aa0e73c70"),
                    CodeIso3 = "ara",
                    Name = "Arabic"
                },
                new Language
                {
                    Id = Guid.Parse("f06aeadf-4112-4169-beaf-fd4f20f146d4"),
                    CodeIso3 = "arc",
                    Name = "Imperial Aramaic"
                },
                new Language
                {
                    Id = Guid.Parse("814dc51c-7313-4c66-bef4-b49c9e5e95e6"),
                    CodeIso3 = "arg",
                    Name = "Aragonese"
                },
                new Language
                {
                    Id = Guid.Parse("a0734543-0353-467b-a3b6-012ea46fb559"),
                    CodeIso3 = "arm",
                    Name = "Armenian"
                },
                new Language
                {
                    Id = Guid.Parse("300f7a0e-623e-4993-842e-00752d4b381b"),
                    CodeIso3 = "arn",
                    Name = "Mapuche"
                },
                new Language
                {
                    Id = Guid.Parse("b61df588-5a51-42a7-9d2d-43e232b11bd1"),
                    CodeIso3 = "arp",
                    Name = "Arapaho"
                },
                new Language
                {
                    Id = Guid.Parse("af216215-8a25-44a1-9aab-956c3e6cb6d3"),
                    CodeIso3 = "art",
                    Name = "Artificial"
                },
                new Language
                {
                    Id = Guid.Parse("c45ecf1a-1605-4512-8fbf-6d202b9806f6"),
                    CodeIso3 = "arw",
                    Name = "Arawak"
                },
                new Language
                {
                    Id = Guid.Parse("0d9e423d-e60c-440b-8504-f1aa9c5483c7"),
                    CodeIso3 = "asm",
                    Name = "Assamese"
                },
                new Language
                {
                    Id = Guid.Parse("a2a64cac-edda-4de8-b5c0-093964954eed"),
                    CodeIso3 = "ast",
                    Name = "Asturleonese"
                },
                new Language
                {
                    Id = Guid.Parse("b4dff308-370e-4dbd-9a5b-d4b37351af8e"),
                    CodeIso3 = "ath",
                    Name = "Athapascan"
                },
                new Language
                {
                    Id = Guid.Parse("cfef773a-db12-4285-855d-6b45ea68ce84"),
                    CodeIso3 = "aus",
                    Name = "Australian"
                },
                new Language
                {
                    Id = Guid.Parse("dde0ae86-71f0-4023-82d6-cd0a2f461810"),
                    CodeIso3 = "ava",
                    Name = "Avaric"
                },
                new Language
                {
                    Id = Guid.Parse("30ce2f19-e18b-488a-9fdf-2ad0960d34ba"),
                    CodeIso3 = "ave",
                    Name = "Avestan"
                },
                new Language
                {
                    Id = Guid.Parse("4de60512-722a-4068-9dcc-c936fd6f2471"),
                    CodeIso3 = "awa",
                    Name = "Awadhi"
                },
                new Language
                {
                    Id = Guid.Parse("42a62610-915d-4c70-a5f2-ec65484370c0"),
                    CodeIso3 = "aym",
                    Name = "Aymara"
                },
                new Language
                {
                    Id = Guid.Parse("da3b0065-efb8-40d4-86d4-187083cd2878"),
                    CodeIso3 = "aze",
                    Name = "Azerbaijani"
                },
                new Language
                {
                    Id = Guid.Parse("843efcbd-18a5-4513-8566-aa30ae08e56b"),
                    CodeIso3 = "bad",
                    Name = "Banda"
                },
                new Language
                {
                    Id = Guid.Parse("954d24f1-3ac8-41c2-8bbc-8ff2ed98e1d6"),
                    CodeIso3 = "bai",
                    Name = "Bamileke"
                },
                new Language
                {
                    Id = Guid.Parse("9be4ebe5-d5e3-4b41-84f0-c5ed5954bea9"),
                    CodeIso3 = "bak",
                    Name = "Bashkir"
                },
                new Language
                {
                    Id = Guid.Parse("46aba2b7-7574-42d8-a4e8-8b22485fecb6"),
                    CodeIso3 = "bal",
                    Name = "Baluchi"
                },
                new Language
                {
                    Id = Guid.Parse("c5e63321-4470-4a70-b0a6-3ce861482734"),
                    CodeIso3 = "bam",
                    Name = "Bambara"
                },
                new Language
                {
                    Id = Guid.Parse("92cfee18-59b9-44f1-b1e9-4ec26f0917b3"),
                    CodeIso3 = "ban",
                    Name = "Balinese"
                },
                new Language
                {
                    Id = Guid.Parse("74a56842-ab2e-42a6-9a2a-f1b4b753069d"),
                    CodeIso3 = "baq",
                    Name = "Basque"
                },
                new Language
                {
                    Id = Guid.Parse("ad2f8f31-50bf-4449-8af7-5d65b44d054d"),
                    CodeIso3 = "bas",
                    Name = "Basa"
                },
                new Language
                {
                    Id = Guid.Parse("acb2e513-a4f9-4a1d-b184-0477e28255be"),
                    CodeIso3 = "bat",
                    Name = "Baltic"
                },
                new Language
                {
                    Id = Guid.Parse("693c7198-b200-49fc-b821-0e1875df5462"),
                    CodeIso3 = "bej",
                    Name = "Bedawiyet"
                },
                new Language
                {
                    Id = Guid.Parse("e330f111-e2fe-47bf-b8d8-033450054962"),
                    CodeIso3 = "bel",
                    Name = "Belarusian"
                },
                new Language
                {
                    Id = Guid.Parse("337d045a-323c-4e8c-83b0-da8c274b6bd9"),
                    CodeIso3 = "bem",
                    Name = "Bemba"
                },
                new Language
                {
                    Id = Guid.Parse("4608c950-8d95-43be-9bf1-afff7cc730d8"),
                    CodeIso3 = "ben",
                    Name = "Bengali"
                },
                new Language
                {
                    Id = Guid.Parse("5495f69a-f7d0-42e8-9a78-254205446750"),
                    CodeIso3 = "ber",
                    Name = "Berber"
                },
                new Language
                {
                    Id = Guid.Parse("39decf6f-09ba-463c-b8ba-fa86cdae9920"),
                    CodeIso3 = "bho",
                    Name = "Bhojpuri"
                },
                new Language
                {
                    Id = Guid.Parse("9df2479d-4335-4b98-a232-22b61b1be60d"),
                    CodeIso3 = "bih",
                    Name = "Bihari"
                },
                new Language
                {
                    Id = Guid.Parse("ed7938e8-832e-44e0-a20e-e94c9dfaa29f"),
                    CodeIso3 = "bik",
                    Name = "Bikol"
                },
                new Language
                {
                    Id = Guid.Parse("04274eda-3c50-4d9c-9e2c-e80254a90372"),
                    CodeIso3 = "bin",
                    Name = "Edo"
                },
                new Language
                {
                    Id = Guid.Parse("7f2028ab-a67a-4056-a5e2-b79a37aa129c"),
                    CodeIso3 = "bis",
                    Name = "Bislama"
                },
                new Language
                {
                    Id = Guid.Parse("e33a1bdc-db82-4948-afaa-5bbeacb32fb3"),
                    CodeIso3 = "bla",
                    Name = "Siksika"
                },
                new Language
                {
                    Id = Guid.Parse("8481a0e7-6162-45f1-b419-87bd31da7245"),
                    CodeIso3 = "bnt",
                    Name = "Bantu"
                },
                new Language
                {
                    Id = Guid.Parse("f353989a-1441-47f3-82a5-e895057e2c9b"),
                    CodeIso3 = "tib",
                    Name = "Tibetan"
                },
                new Language
                {
                    Id = Guid.Parse("cfd10e10-9a31-4005-8aae-83e6e8ef3dc3"),
                    CodeIso3 = "bos",
                    Name = "Bosnian"
                },
                new Language
                {
                    Id = Guid.Parse("a33a79ea-4663-46e1-b8c5-0125f652409e"),
                    CodeIso3 = "bra",
                    Name = "Braj"
                },
                new Language
                {
                    Id = Guid.Parse("5b6788eb-3923-44d5-a6e9-18bc34c2c16c"),
                    CodeIso3 = "bre",
                    Name = "Breton"
                },
                new Language
                {
                    Id = Guid.Parse("1bc11166-0e94-464f-989f-a3abfce4ec1f"),
                    CodeIso3 = "btk",
                    Name = "Batak"
                },
                new Language
                {
                    Id = Guid.Parse("870019e8-88a1-411b-baba-bbb02957917f"),
                    CodeIso3 = "bua",
                    Name = "Buriat"
                },
                new Language
                {
                    Id = Guid.Parse("21ac8114-5160-4cb0-b090-4ca93ee06120"),
                    CodeIso3 = "bug",
                    Name = "Buginese"
                },
                new Language
                {
                    Id = Guid.Parse("88576b3a-9d96-47a4-82d1-09b95b776b13"),
                    CodeIso3 = "bul",
                    Name = "Bulgarian"
                },
                new Language
                {
                    Id = Guid.Parse("e8095514-9d86-449e-97f0-3b5d71f41d1e"),
                    CodeIso3 = "bur",
                    Name = "Burmese"
                },
                new Language
                {
                    Id = Guid.Parse("f6925853-6d9d-4ba9-90fb-37703ff6d74a"),
                    CodeIso3 = "byn",
                    Name = "Bilin"
                },
                new Language
                {
                    Id = Guid.Parse("bb73f3d7-0dab-44cb-84a0-8a890ebcde2a"),
                    CodeIso3 = "cad",
                    Name = "Caddo"
                },
                new Language
                {
                    Id = Guid.Parse("7f74df3e-d04e-4540-874b-05509c9cc999"),
                    CodeIso3 = "cai",
                    Name = "Central American Indian"
                },
                new Language
                {
                    Id = Guid.Parse("fdb0b80c-e09c-469a-92c2-333c019135a0"),
                    CodeIso3 = "car",
                    Name = "Galibi Carib"
                },
                new Language
                {
                    Id = Guid.Parse("cc22ca64-1c76-43d1-a1c9-3123f0f8c9c5"),
                    CodeIso3 = "cat",
                    Name = "Valencian"
                },
                new Language
                {
                    Id = Guid.Parse("bb0c662d-9b69-42f4-ac54-8db8785f015f"),
                    CodeIso3 = "cau",
                    Name = "Caucasian"
                },
                new Language
                {
                    Id = Guid.Parse("fd00dc9f-7a06-4c8e-b132-343f02c89b90"),
                    CodeIso3 = "ceb",
                    Name = "Cebuano"
                },
                new Language
                {
                    Id = Guid.Parse("5891b249-f4d0-4ce9-bc63-5f42795333ed"),
                    CodeIso3 = "cel",
                    Name = "Celtic"
                },
                new Language
                {
                    Id = Guid.Parse("bb5f795b-a4e5-473d-9359-856a0fa0a82c"),
                    CodeIso3 = "cze",
                    Name = "Czech"
                },
                new Language
                {
                    Id = Guid.Parse("90e61fb8-8ffd-4668-90a2-6f1f3b007044"),
                    CodeIso3 = "cha",
                    Name = "Chamorro"
                },
                new Language
                {
                    Id = Guid.Parse("139ef826-10d7-430f-8cd1-8018403436ef"),
                    CodeIso3 = "chb",
                    Name = "Chibcha"
                },
                new Language
                {
                    Id = Guid.Parse("508b1a77-cb36-48e1-82e7-3b7f77a38f6b"),
                    CodeIso3 = "che",
                    Name = "Chechen"
                },
                new Language
                {
                    Id = Guid.Parse("68fcd855-d1b4-42eb-9537-17c7ce7d82b4"),
                    CodeIso3 = "chg",
                    Name = "Chagatai"
                },
                new Language
                {
                    Id = Guid.Parse("0ad96271-7e4e-4a1e-b7cb-d84627d66ecf"),
                    CodeIso3 = "chi",
                    Name = "Chinese"
                },
                new Language
                {
                    Id = Guid.Parse("84ef75cc-c3ee-4af3-a95a-4ee03fd16a5a"),
                    CodeIso3 = "chk",
                    Name = "Chuukese"
                },
                new Language
                {
                    Id = Guid.Parse("6bbc3790-254a-46dd-895a-f2c5e94e03a5"),
                    CodeIso3 = "chm",
                    Name = "Mari"
                },
                new Language
                {
                    Id = Guid.Parse("a04fffce-2eb3-429a-9f1e-94f953a883dc"),
                    CodeIso3 = "chn",
                    Name = "Chinook jargon"
                },
                new Language
                {
                    Id = Guid.Parse("3611d0fc-e181-4330-ad42-b37e91b500e8"),
                    CodeIso3 = "cho",
                    Name = "Choctaw"
                },
                new Language
                {
                    Id = Guid.Parse("b967e926-e5ec-4f46-9c26-50af79c8a0d0"),
                    CodeIso3 = "chp",
                    Name = "Dene Suline"
                },
                new Language
                {
                    Id = Guid.Parse("1206a99e-b491-4a1a-b94b-4ebafedc1e14"),
                    CodeIso3 = "chr",
                    Name = "Cherokee"
                },
                new Language
                {
                    Id = Guid.Parse("2830ffbb-bcba-4efa-afc3-0f81ae4cdeb3"),
                    CodeIso3 = "chu",
                    Name = "Old Church Slavonic"
                },
                new Language
                {
                    Id = Guid.Parse("ed287fc5-55c2-46cf-9d85-0464d1d9c9db"),
                    CodeIso3 = "chv",
                    Name = "Chuvash"
                },
                new Language
                {
                    Id = Guid.Parse("7933e7c6-1cde-4348-8c69-9c4ab1efe1ed"),
                    CodeIso3 = "chy",
                    Name = "Cheyenne"
                },
                new Language
                {
                    Id = Guid.Parse("026daa7f-82db-4205-b4f5-72dad918a5ad"),
                    CodeIso3 = "cmc",
                    Name = "Chamic"
                },
                new Language
                {
                    Id = Guid.Parse("43560b32-5493-4a78-9653-d5c926e8259d"),
                    CodeIso3 = "cnr",
                    Name = "Montenegrin"
                },
                new Language
                {
                    Id = Guid.Parse("9eaebcad-903f-43d0-b1be-8bab852a509e"),
                    CodeIso3 = "cop",
                    Name = "Coptic"
                },
                new Language
                {
                    Id = Guid.Parse("7198dca7-4ceb-4a74-95bd-73bad1ea4b43"),
                    CodeIso3 = "cor",
                    Name = "Cornish"
                },
                new Language
                {
                    Id = Guid.Parse("d08af630-d2b0-4429-b4b6-d70a7df1abf1"),
                    CodeIso3 = "cos",
                    Name = "Corsican"
                },
                new Language
                {
                    Id = Guid.Parse("2e9f1d06-8302-4b2d-bc2a-bb0b029688f7"),
                    CodeIso3 = "cpe",
                    Name = "Creoles and pidgins, English based"
                },
                new Language
                {
                    Id = Guid.Parse("89c8fa66-db94-49ae-be75-d60279485ea5"),
                    CodeIso3 = "cpf",
                    Name = "Creoles and pidgins, French-based"
                },
                new Language
                {
                    Id = Guid.Parse("f22c5400-c3cf-4bab-a0fb-8fb5dbb28b67"),
                    CodeIso3 = "cpp",
                    Name = "Creoles and pidgins, Portuguese-based"
                },
                new Language
                {
                    Id = Guid.Parse("5ddb4787-58d0-42b7-948b-e999c4c08ab1"),
                    CodeIso3 = "cre",
                    Name = "Cree"
                },
                new Language
                {
                    Id = Guid.Parse("181e71cb-27ea-4965-bf5b-19fcd6b9dc76"),
                    CodeIso3 = "crh",
                    Name = "Crimean Turkish"
                },
                new Language
                {
                    Id = Guid.Parse("24f83540-5308-423c-9553-2badcaad5c15"),
                    CodeIso3 = "crp",
                    Name = "Creoles and pidgins"
                },
                new Language
                {
                    Id = Guid.Parse("985888f4-d632-4385-9a50-9c87a6c675be"),
                    CodeIso3 = "csb",
                    Name = "Kashubian"
                },
                new Language
                {
                    Id = Guid.Parse("abbb546e-6244-4f97-8168-27e8b1bfcf5c"),
                    CodeIso3 = "cus",
                    Name = "Cushitic"
                },
                new Language
                {
                    Id = Guid.Parse("77478b9c-d9e2-49c1-a239-b845da8709cf"),
                    CodeIso3 = "wel",
                    Name = "Welsh"
                },
                new Language
                {
                    Id = Guid.Parse("7e4b18ea-b1a8-49e3-a7ce-fe8fdf53c977"),
                    CodeIso3 = "cze",
                    Name = "Czech"
                },
                new Language
                {
                    Id = Guid.Parse("49c40443-3b0c-4a54-9100-538d38c14909"),
                    CodeIso3 = "dak",
                    Name = "Dakota"
                },
                new Language
                {
                    Id = Guid.Parse("c771615a-02ce-4f73-ad3c-5569dec9b4d5"),
                    CodeIso3 = "dan",
                    Name = "Danish"
                },
                new Language
                {
                    Id = Guid.Parse("5994b760-265c-42ff-b999-93f8de79ffdb"),
                    CodeIso3 = "dar",
                    Name = "Dargwa"
                },
                new Language
                {
                    Id = Guid.Parse("cecfd81b-09ef-4226-9d21-66c210cae8fe"),
                    CodeIso3 = "day",
                    Name = "Land Dayak"
                },
                new Language
                {
                    Id = Guid.Parse("c64ffc8f-3c79-453d-af62-87f4c622c213"),
                    CodeIso3 = "del",
                    Name = "Delaware"
                },
                new Language
                {
                    Id = Guid.Parse("395e9197-a944-4a6e-92b8-e32e40b6e692"),
                    CodeIso3 = "den",
                    Name = "Slave"
                },
                new Language
                {
                    Id = Guid.Parse("22206a3b-a2c0-42bc-9ad8-555a83b532cb"),
                    CodeIso3 = "ger",
                    Name = "German"
                },
                new Language
                {
                    Id = Guid.Parse("e7c1eb5a-f5a5-42f0-bf8b-499a6f0dee11"),
                    CodeIso3 = "dgr",
                    Name = "Dogrib"
                },
                new Language
                {
                    Id = Guid.Parse("479e1a9c-8259-47ab-a7d5-a9cf55071588"),
                    CodeIso3 = "din",
                    Name = "Dinka"
                },
                new Language
                {
                    Id = Guid.Parse("76f60e15-f534-4406-abc7-4e712869c60c"),
                    CodeIso3 = "div",
                    Name = "Maldivian"
                },
                new Language
                {
                    Id = Guid.Parse("855a0c42-b839-467e-86bd-4aec98cf7446"),
                    CodeIso3 = "doi",
                    Name = "Dogri"
                },
                new Language
                {
                    Id = Guid.Parse("8e45f499-b6a7-40f7-8da7-65772640a584"),
                    CodeIso3 = "dra",
                    Name = "Dravidian"
                },
                new Language
                {
                    Id = Guid.Parse("6ca047c9-d23e-4d11-8c01-29da8e745def"),
                    CodeIso3 = "dsb",
                    Name = "Lower Sorbian"
                },
                new Language
                {
                    Id = Guid.Parse("21afd8b5-98af-4918-88bf-9ef3771aa63a"),
                    CodeIso3 = "dua",
                    Name = "Duala"
                },
                new Language
                {
                    Id = Guid.Parse("84974b7e-3e6d-413d-aa4b-f3134ca21a1c"),
                    CodeIso3 = "dum",
                    Name = "Dutch, Middle"
                },
                new Language
                {
                    Id = Guid.Parse("db1379d0-cc2c-4e86-a802-0a7c508b51f0"),
                    CodeIso3 = "dut",
                    Name = "Flemish"
                },
                new Language
                {
                    Id = Guid.Parse("9aba7e0d-5a1a-4778-99f0-1293a10390e3"),
                    CodeIso3 = "dyu",
                    Name = "Dyula"
                },
                new Language
                {
                    Id = Guid.Parse("fa2a20c5-9d2f-4156-9c2e-005cfdb3b1b4"),
                    CodeIso3 = "dzo",
                    Name = "Dzongkha"
                },
                new Language
                {
                    Id = Guid.Parse("f1613709-e298-4c77-8a84-0ead93dde7d1"),
                    CodeIso3 = "efi",
                    Name = "Efik"
                },
                new Language
                {
                    Id = Guid.Parse("2ec78727-a0ca-43d0-97b2-8651c8adb223"),
                    CodeIso3 = "egy",
                    Name = "Egyptian"
                },
                new Language
                {
                    Id = Guid.Parse("1a87adf8-6ecf-470e-84c9-d7c8d776aae5"),
                    CodeIso3 = "eka",
                    Name = "Ekajuk"
                },
                new Language
                {
                    Id = Guid.Parse("e727b9fe-2deb-49ff-af77-fc33b4471be9"),
                    CodeIso3 = "gre",
                    Name = "Greek, Modern"
                },
                new Language
                {
                    Id = Guid.Parse("0f306d22-2f4b-454b-bae3-78a5c9ec0ee6"),
                    CodeIso3 = "elx",
                    Name = "Elamite"
                },
                new Language
                {
                    Id = Guid.Parse("178c9e13-fa02-4b90-8c0d-b9b11cf988fb"),
                    CodeIso3 = "eng",
                    Name = "English"
                },
                new Language
                {
                    Id = Guid.Parse("28a99be2-104d-4cbe-884e-fa37e2c01e46"),
                    CodeIso3 = "enm",
                    Name = "English, Middle"
                },
                new Language
                {
                    Id = Guid.Parse("fb28cc29-e9a3-488e-b913-b526f30dc595"),
                    CodeIso3 = "epo",
                    Name = "Esperanto"
                },
                new Language
                {
                    Id = Guid.Parse("c1a3227d-1ea5-4944-9355-027d80814dc3"),
                    CodeIso3 = "est",
                    Name = "Estonian"
                },
                new Language
                {
                    Id = Guid.Parse("b7c468ea-5dee-4d1c-abc7-01caac56b92e"),
                    CodeIso3 = "baq",
                    Name = "Basque"
                },
                new Language
                {
                    Id = Guid.Parse("b74dda54-41cb-45a7-8bb3-2cbeba6568c9"),
                    CodeIso3 = "ewe",
                    Name = "Ewe"
                },
                new Language
                {
                    Id = Guid.Parse("cea203fa-577c-48c2-9a91-937f0be234a2"),
                    CodeIso3 = "ewo",
                    Name = "Ewondo"
                },
                new Language
                {
                    Id = Guid.Parse("1e74fc64-301d-4512-98aa-bae8e46a2e2f"),
                    CodeIso3 = "fan",
                    Name = "Fang"
                },
                new Language
                {
                    Id = Guid.Parse("162de8d8-687d-44f4-87df-2978ac39c4a3"),
                    CodeIso3 = "fao",
                    Name = "Faroese"
                },
                new Language
                {
                    Id = Guid.Parse("c566d5c9-f45a-42ff-813a-9d1631576600"),
                    CodeIso3 = "per",
                    Name = "Persian"
                },
                new Language
                {
                    Id = Guid.Parse("2c39a737-9df7-463c-8a86-d0648041411f"),
                    CodeIso3 = "fat",
                    Name = "Fanti"
                },
                new Language
                {
                    Id = Guid.Parse("0721d658-3de0-4be0-b77f-2df989736d95"),
                    CodeIso3 = "fij",
                    Name = "Fijian"
                },
                new Language
                {
                    Id = Guid.Parse("628e67c2-7594-44fd-bf32-3c646868a041"),
                    CodeIso3 = "fil",
                    Name = "Pilipino"
                },
                new Language
                {
                    Id = Guid.Parse("cc6e1e27-1ab1-4a06-ad5e-99230cf5b185"),
                    CodeIso3 = "fin",
                    Name = "Finnish"
                },
                new Language
                {
                    Id = Guid.Parse("67a6fdf3-b26c-494e-87ff-9ed9b76f977a"),
                    CodeIso3 = "fiu",
                    Name = "Finno-Ugrian"
                },
                new Language
                {
                    Id = Guid.Parse("29dfda71-1141-41a4-bccf-5d6a0d46bc37"),
                    CodeIso3 = "fon",
                    Name = "Fon"
                },
                new Language
                {
                    Id = Guid.Parse("9a552e63-50f6-4e22-9a14-ce8a4218c064"),
                    CodeIso3 = "fre",
                    Name = "French"
                },
                new Language
                {
                    Id = Guid.Parse("89b718ee-79fb-4448-b511-c7e6b5f4ce7b"),
                    CodeIso3 = "fre",
                    Name = "French"
                },
                new Language
                {
                    Id = Guid.Parse("c6fcfa94-0c5f-4d93-8869-65b4ef6d045a"),
                    CodeIso3 = "frm",
                    Name = "French, Middle"
                },
                new Language
                {
                    Id = Guid.Parse("d32571c7-1624-4773-b3d7-002e569948a8"),
                    CodeIso3 = "fro",
                    Name = "French, Old"
                },
                new Language
                {
                    Id = Guid.Parse("f8eb23bd-38f8-4383-abe8-ec69a76050d9"),
                    CodeIso3 = "frr",
                    Name = "Northern Frisian"
                },
                new Language
                {
                    Id = Guid.Parse("415337ee-ee1a-4f14-9970-615a12407ff4"),
                    CodeIso3 = "frs",
                    Name = "Eastern Frisian"
                },
                new Language
                {
                    Id = Guid.Parse("0bd52da2-f668-41f4-8f2a-149ba56052b9"),
                    CodeIso3 = "fry",
                    Name = "Western Frisian"
                },
                new Language
                {
                    Id = Guid.Parse("90d5e14c-e10c-49dc-bd9c-f677d3944815"),
                    CodeIso3 = "ful",
                    Name = "Fulah"
                },
                new Language
                {
                    Id = Guid.Parse("c452e630-0977-4c4f-9c16-c843588bcd2b"),
                    CodeIso3 = "fur",
                    Name = "Friulian"
                },
                new Language
                {
                    Id = Guid.Parse("3bdd18c8-780c-440c-9dcc-e582d7057423"),
                    CodeIso3 = "gaa",
                    Name = "Ga"
                },
                new Language
                {
                    Id = Guid.Parse("3a38bae6-4b2e-47e4-8cfb-37f906ff9b88"),
                    CodeIso3 = "gay",
                    Name = "Gayo"
                },
                new Language
                {
                    Id = Guid.Parse("1305cf63-5033-43df-96e7-83633a822d5c"),
                    CodeIso3 = "gba",
                    Name = "Gbaya"
                },
                new Language
                {
                    Id = Guid.Parse("cacc6531-d4bb-4099-9010-098480a793ef"),
                    CodeIso3 = "gem",
                    Name = "Germanic"
                },
                new Language
                {
                    Id = Guid.Parse("1a4501d1-5cad-48db-b8ab-5186d347a906"),
                    CodeIso3 = "geo",
                    Name = "Georgian"
                },
                new Language
                {
                    Id = Guid.Parse("be69ad1c-6d69-4a05-96f2-84ebc329ef87"),
                    CodeIso3 = "ger",
                    Name = "German"
                },
                new Language
                {
                    Id = Guid.Parse("b2181328-d2f1-4eb9-b924-e0264bb38c21"),
                    CodeIso3 = "gez",
                    Name = "Geez"
                },
                new Language
                {
                    Id = Guid.Parse("5b2a17ae-1672-489e-b009-62a83265cb50"),
                    CodeIso3 = "gil",
                    Name = "Gilbertese"
                },
                new Language
                {
                    Id = Guid.Parse("a3f23017-ad48-470f-8af7-d39c7b82049d"),
                    CodeIso3 = "gla",
                    Name = "Scottish Gaelic"
                },
                new Language
                {
                    Id = Guid.Parse("323f9b50-d08a-436f-b648-7c44a2ceffcb"),
                    CodeIso3 = "gle",
                    Name = "Irish"
                },
                new Language
                {
                    Id = Guid.Parse("c60108a3-a138-4d61-a10a-d04205d32f38"),
                    CodeIso3 = "glg",
                    Name = "Galician"
                },
                new Language
                {
                    Id = Guid.Parse("e6786386-b9cf-44b9-835b-3685dd73942b"),
                    CodeIso3 = "glv",
                    Name = "Manx"
                },
                new Language
                {
                    Id = Guid.Parse("51d0abce-9a9b-4f41-9f8a-52d7100abc3b"),
                    CodeIso3 = "gmh",
                    Name = "German, Middle High"
                },
                new Language
                {
                    Id = Guid.Parse("f3d3104a-269c-4750-a1f8-d736013aae56"),
                    CodeIso3 = "goh",
                    Name = "German, Old High"
                },
                new Language
                {
                    Id = Guid.Parse("bd63cec6-3eb0-488f-9379-f96fddf7198d"),
                    CodeIso3 = "gon",
                    Name = "Gondi"
                },
                new Language
                {
                    Id = Guid.Parse("7c3ff242-8dda-42bb-a867-7941f009276c"),
                    CodeIso3 = "gor",
                    Name = "Gorontalo"
                },
                new Language
                {
                    Id = Guid.Parse("6a83e39c-014f-401a-8915-f57a8497e85f"),
                    CodeIso3 = "got",
                    Name = "Gothic"
                },
                new Language
                {
                    Id = Guid.Parse("cbc4178e-aaf0-4dca-a5ab-bf0134c9c606"),
                    CodeIso3 = "grb",
                    Name = "Grebo"
                },
                new Language
                {
                    Id = Guid.Parse("d29aa24a-b126-4c43-9f8d-f1a4a2fc70fe"),
                    CodeIso3 = "grc",
                    Name = "Greek, Ancient"
                },
                new Language
                {
                    Id = Guid.Parse("aa23ec7e-c0fa-4f79-b953-3ac5d7e42c12"),
                    CodeIso3 = "gre",
                    Name = "Greek, Modern"
                },
                new Language
                {
                    Id = Guid.Parse("2dc5fdb2-9d07-43a8-8b9b-e17b90068de4"),
                    CodeIso3 = "grn",
                    Name = "Guarani"
                },
                new Language
                {
                    Id = Guid.Parse("4126c35f-0e7d-4037-9708-fb36c53f222c"),
                    CodeIso3 = "gsw",
                    Name = "Alsatian"
                },
                new Language
                {
                    Id = Guid.Parse("8709d123-9af3-4434-a532-ee5bd6d28972"),
                    CodeIso3 = "guj",
                    Name = "Gujarati"
                },
                new Language
                {
                    Id = Guid.Parse("e22cc7d6-7c09-43f7-b474-31499cdd70b8"),
                    CodeIso3 = "gwi",
                    Name = "Gwich'in"
                },
                new Language
                {
                    Id = Guid.Parse("5082cac6-86d7-4776-8e9b-93df05509e12"),
                    CodeIso3 = "hai",
                    Name = "Haida"
                },
                new Language
                {
                    Id = Guid.Parse("fc172584-6770-46c7-b19c-27961adcc8dc"),
                    CodeIso3 = "hat",
                    Name = "Haitian Creole"
                },
                new Language
                {
                    Id = Guid.Parse("bb7c8915-370e-4d90-bcd1-abe362bc7769"),
                    CodeIso3 = "hau",
                    Name = "Hausa"
                },
                new Language
                {
                    Id = Guid.Parse("fab1aefa-a025-42cb-9993-8bff1d9f3062"),
                    CodeIso3 = "haw",
                    Name = "Hawaiian"
                },
                new Language
                {
                    Id = Guid.Parse("f3f5f3c9-adf2-49ed-af08-b8b57dc1e22f"),
                    CodeIso3 = "heb",
                    Name = "Hebrew"
                },
                new Language
                {
                    Id = Guid.Parse("fb593a41-c5bb-4f24-b2dc-a5640ec7e5ac"),
                    CodeIso3 = "her",
                    Name = "Herero"
                },
                new Language
                {
                    Id = Guid.Parse("e1053d48-84c9-49de-a1e5-ecd8abdf5d94"),
                    CodeIso3 = "hil",
                    Name = "Hiligaynon"
                },
                new Language
                {
                    Id = Guid.Parse("48875311-7725-4816-803a-716c95cb6bc0"),
                    CodeIso3 = "him",
                    Name = "Western Pahari"
                },
                new Language
                {
                    Id = Guid.Parse("20e6f470-814d-4c06-9f0e-80f32e797bea"),
                    CodeIso3 = "hin",
                    Name = "Hindi"
                },
                new Language
                {
                    Id = Guid.Parse("43543e8f-a005-433b-8039-d00cedd545c6"),
                    CodeIso3 = "hit",
                    Name = "Hittite"
                },
                new Language
                {
                    Id = Guid.Parse("9e99810b-cdc1-4682-9a64-af7e56bbebb3"),
                    CodeIso3 = "hmn",
                    Name = "Mong"
                },
                new Language
                {
                    Id = Guid.Parse("ca4d88fd-131a-425e-b7d7-4799d0117461"),
                    CodeIso3 = "hmo",
                    Name = "Hiri Motu"
                },
                new Language
                {
                    Id = Guid.Parse("e31098cd-8eaa-45ec-bdb1-3de3d5c29a1c"),
                    CodeIso3 = "hrv",
                    Name = "Croatian"
                },
                new Language
                {
                    Id = Guid.Parse("f6455f36-2694-44ba-8eb8-2ee9f0391c77"),
                    CodeIso3 = "hsb",
                    Name = "Upper Sorbian"
                },
                new Language
                {
                    Id = Guid.Parse("d611c712-bfc6-4c30-a419-9a1f5b0b94c6"),
                    CodeIso3 = "hun",
                    Name = "Hungarian"
                },
                new Language
                {
                    Id = Guid.Parse("9fb5161f-ae56-4bfb-aa4c-b89dd452b6fe"),
                    CodeIso3 = "hup",
                    Name = "Hupa"
                },
                new Language
                {
                    Id = Guid.Parse("f637223f-cd8b-4588-b983-6adeda682ed9"),
                    CodeIso3 = "arm",
                    Name = "Armenian"
                },
                new Language
                {
                    Id = Guid.Parse("bb012dbd-b8b2-46ac-9c41-b9965a5e65d6"),
                    CodeIso3 = "iba",
                    Name = "Iban"
                },
                new Language
                {
                    Id = Guid.Parse("d1bfc743-a3cd-4674-868a-266264b49bcf"),
                    CodeIso3 = "ibo",
                    Name = "Igbo"
                },
                new Language
                {
                    Id = Guid.Parse("8eb2fc29-d1ac-4317-b456-143cc35841df"),
                    CodeIso3 = "ice",
                    Name = "Icelandic"
                },
                new Language
                {
                    Id = Guid.Parse("8e7136da-665f-4726-bb75-2d405c40487c"),
                    CodeIso3 = "ido",
                    Name = "Ido"
                },
                new Language
                {
                    Id = Guid.Parse("902de7bc-c18b-4a71-9090-a8bd6b642546"),
                    CodeIso3 = "iii",
                    Name = "Nuosu"
                },
                new Language
                {
                    Id = Guid.Parse("141a019c-3aa5-4161-b4c2-50f3bc93d627"),
                    CodeIso3 = "ijo",
                    Name = "Ijo"
                },
                new Language
                {
                    Id = Guid.Parse("bea8938a-48c4-4993-9c23-ea8cd2de58ce"),
                    CodeIso3 = "iku",
                    Name = "Inuktitut"
                },
                new Language
                {
                    Id = Guid.Parse("b42d3d69-96d6-4047-b521-9b28d41b4f6a"),
                    CodeIso3 = "ile",
                    Name = "Occidental"
                },
                new Language
                {
                    Id = Guid.Parse("c5c18905-6df1-4322-ae9e-12fccbe4967d"),
                    CodeIso3 = "ilo",
                    Name = "Iloko"
                },
                new Language
                {
                    Id = Guid.Parse("36d5a702-a712-4340-bafe-6ec9581b5404"),
                    CodeIso3 = "ina",
                    Name = "Interlingua"
                },
                new Language
                {
                    Id = Guid.Parse("f4b65043-309c-4cf1-abd7-1ed3d9cc774e"),
                    CodeIso3 = "inc",
                    Name = "Indic"
                },
                new Language
                {
                    Id = Guid.Parse("fc9f802a-d566-4448-94aa-d22154babb6f"),
                    CodeIso3 = "ind",
                    Name = "Indonesian"
                },
                new Language
                {
                    Id = Guid.Parse("3e871780-2e4e-4584-860a-505a989fabfe"),
                    CodeIso3 = "ine",
                    Name = "Indo-European"
                },
                new Language
                {
                    Id = Guid.Parse("af281d14-2551-4569-b75a-1efa1d9bce75"),
                    CodeIso3 = "inh",
                    Name = "Ingush"
                },
                new Language
                {
                    Id = Guid.Parse("79297c25-ba5a-4bfb-8f91-2e678b5adff1"),
                    CodeIso3 = "ipk",
                    Name = "Inupiaq"
                },
                new Language
                {
                    Id = Guid.Parse("8c840b31-59f8-4552-abcc-8a98497a2cbc"),
                    CodeIso3 = "ira",
                    Name = "Iranian"
                },
                new Language
                {
                    Id = Guid.Parse("4391e221-9107-4452-a4e3-7d9ae0805064"),
                    CodeIso3 = "iro",
                    Name = "Iroquoian"
                },
                new Language
                {
                    Id = Guid.Parse("6114ba63-ae6b-4306-8ab7-f6642ca64530"),
                    CodeIso3 = "ice",
                    Name = "Icelandic"
                },
                new Language
                {
                    Id = Guid.Parse("c06559c5-97bb-4baf-a406-e5f630268af2"),
                    CodeIso3 = "ita",
                    Name = "Italian"
                },
                new Language
                {
                    Id = Guid.Parse("f540298e-5d37-4c86-b98d-fc42a4dba466"),
                    CodeIso3 = "jav",
                    Name = "Javanese"
                },
                new Language
                {
                    Id = Guid.Parse("66ef2ee7-d4d0-47ef-98dc-0a46327194a0"),
                    CodeIso3 = "jbo",
                    Name = "Lojban"
                },
                new Language
                {
                    Id = Guid.Parse("ec9d7439-2a6f-45ad-ab4f-4e807177402a"),
                    CodeIso3 = "jpn",
                    Name = "Japanese"
                },
                new Language
                {
                    Id = Guid.Parse("acd811f2-a55a-413c-a188-727319a49c88"),
                    CodeIso3 = "jpr",
                    Name = "Judeo-Persian"
                },
                new Language
                {
                    Id = Guid.Parse("c0a2a5fc-b6d2-46cb-890d-4f4bed48fde4"),
                    CodeIso3 = "jrb",
                    Name = "Judeo-Arabic"
                },
                new Language
                {
                    Id = Guid.Parse("131ac757-e5a5-42e9-9a45-3d109275db94"),
                    CodeIso3 = "kaa",
                    Name = "Kara-Kalpak"
                },
                new Language
                {
                    Id = Guid.Parse("6a4548bd-91cd-4f7f-9cc6-a0124041ce7e"),
                    CodeIso3 = "kab",
                    Name = "Kabyle"
                },
                new Language
                {
                    Id = Guid.Parse("40c96da3-272d-44ba-938a-eb17a4bade60"),
                    CodeIso3 = "kac",
                    Name = "Jingpho"
                },
                new Language
                {
                    Id = Guid.Parse("e892128f-ba45-4441-953d-0f02a523f4a8"),
                    CodeIso3 = "kal",
                    Name = "Greenlandic"
                },
                new Language
                {
                    Id = Guid.Parse("8caec8e6-9ecf-4bc4-89ed-86a3a15cf901"),
                    CodeIso3 = "kam",
                    Name = "Kamba"
                },
                new Language
                {
                    Id = Guid.Parse("23651329-5b88-440c-9481-81cb6001c140"),
                    CodeIso3 = "kan",
                    Name = "Kannada"
                },
                new Language
                {
                    Id = Guid.Parse("7cfc2c0b-2e02-40ad-b5ee-aedc6b275b95"),
                    CodeIso3 = "kar",
                    Name = "Karen"
                },
                new Language
                {
                    Id = Guid.Parse("5a05e33f-434e-46f0-9ef5-9b5504e1897d"),
                    CodeIso3 = "kas",
                    Name = "Kashmiri"
                },
                new Language
                {
                    Id = Guid.Parse("d7e14e8a-aee0-4bfd-ba3a-842e854cb655"),
                    CodeIso3 = "geo",
                    Name = "Georgian"
                },
                new Language
                {
                    Id = Guid.Parse("cb60d5eb-a9cd-4162-a3ce-7aceac4104d6"),
                    CodeIso3 = "kau",
                    Name = "Kanuri"
                },
                new Language
                {
                    Id = Guid.Parse("d801ee3f-776c-4de3-bf47-8f7e30c5ee18"),
                    CodeIso3 = "kaw",
                    Name = "Kawi"
                },
                new Language
                {
                    Id = Guid.Parse("863bdb0a-0c50-4cf5-8ef0-96cca48773e2"),
                    CodeIso3 = "kaz",
                    Name = "Kazakh"
                },
                new Language
                {
                    Id = Guid.Parse("6288cb20-c76d-4c79-9bd8-6ab453f46a21"),
                    CodeIso3 = "kbd",
                    Name = "Kabardian"
                },
                new Language
                {
                    Id = Guid.Parse("a8d29022-baae-426b-84bc-cc7aaa1d8d26"),
                    CodeIso3 = "kha",
                    Name = "Khasi"
                },
                new Language
                {
                    Id = Guid.Parse("01d85879-694b-4118-84c5-c6c8bd6c4b8d"),
                    CodeIso3 = "khi",
                    Name = "Khoisan"
                },
                new Language
                {
                    Id = Guid.Parse("0638aa74-9e04-431f-a7cc-04d0a79bd9ce"),
                    CodeIso3 = "khm",
                    Name = "Central Khmer"
                },
                new Language
                {
                    Id = Guid.Parse("cf80bd37-f298-4550-9845-db24f1ecb600"),
                    CodeIso3 = "kho",
                    Name = "Sakan"
                },
                new Language
                {
                    Id = Guid.Parse("cd3bfd9f-f23c-43c9-bdbf-bd3a675d9611"),
                    CodeIso3 = "kik",
                    Name = "Gikuyu"
                },
                new Language
                {
                    Id = Guid.Parse("26d41ca3-272e-4c63-ae86-9fd2c591130e"),
                    CodeIso3 = "kin",
                    Name = "Kinyarwanda"
                },
                new Language
                {
                    Id = Guid.Parse("31005bff-2620-47a4-9a56-061ac0df3c0a"),
                    CodeIso3 = "kir",
                    Name = "Kyrgyz"
                },
                new Language
                {
                    Id = Guid.Parse("34d7a5c2-6064-4d6f-aa69-eb9b516e950f"),
                    CodeIso3 = "kmb",
                    Name = "Kimbundu"
                },
                new Language
                {
                    Id = Guid.Parse("3e7682db-8ecb-42d0-a6e3-f9d86cc33ae0"),
                    CodeIso3 = "kok",
                    Name = "Konkani"
                },
                new Language
                {
                    Id = Guid.Parse("d1e6e713-9ef8-4de5-a089-4e31c786ea30"),
                    CodeIso3 = "kom",
                    Name = "Komi"
                },
                new Language
                {
                    Id = Guid.Parse("1797069f-9e1d-454b-98ea-d8d6cce9ddbd"),
                    CodeIso3 = "kon",
                    Name = "Kongo"
                },
                new Language
                {
                    Id = Guid.Parse("763d5e34-acba-4bb7-8415-d26d3dbb5119"),
                    CodeIso3 = "kor",
                    Name = "Korean"
                },
                new Language
                {
                    Id = Guid.Parse("c750bbba-581e-41b6-936e-fa11fa9e18d2"),
                    CodeIso3 = "kos",
                    Name = "Kosraean"
                },
                new Language
                {
                    Id = Guid.Parse("c1f9dbf5-9815-4cc9-92d7-26ec997b7efe"),
                    CodeIso3 = "kpe",
                    Name = "Kpelle"
                },
                new Language
                {
                    Id = Guid.Parse("75ef4e71-c54d-41ea-b2ef-e273fdff9074"),
                    CodeIso3 = "krc",
                    Name = "Karachay-Balkar"
                },
                new Language
                {
                    Id = Guid.Parse("34700c02-c2c8-41fd-97eb-e5c302aec710"),
                    CodeIso3 = "krl",
                    Name = "Karelian"
                },
                new Language
                {
                    Id = Guid.Parse("8b9a482e-b0ac-4b90-89ec-dcc25ec3f12f"),
                    CodeIso3 = "kro",
                    Name = "Kru"
                },
                new Language
                {
                    Id = Guid.Parse("41797f00-5424-4719-a720-c6eeef6f0213"),
                    CodeIso3 = "kru",
                    Name = "Kurukh"
                },
                new Language
                {
                    Id = Guid.Parse("893fe21c-c3b5-4520-82a2-d7d0d47b0eb0"),
                    CodeIso3 = "kua",
                    Name = "Kwanyama"
                },
                new Language
                {
                    Id = Guid.Parse("498435d2-69cb-4c5d-aba5-a483d3b74830"),
                    CodeIso3 = "kum",
                    Name = "Kumyk"
                },
                new Language
                {
                    Id = Guid.Parse("f1135781-41bf-4b5b-b74a-7915a78da967"),
                    CodeIso3 = "kur",
                    Name = "Kurdish"
                },
                new Language
                {
                    Id = Guid.Parse("b934f6a7-e9ee-4555-b1d2-d706e2df81ce"),
                    CodeIso3 = "kut",
                    Name = "Kutenai"
                },
                new Language
                {
                    Id = Guid.Parse("0cdc572c-6ff8-408d-be9d-85041821e403"),
                    CodeIso3 = "lad",
                    Name = "Ladino"
                },
                new Language
                {
                    Id = Guid.Parse("53b8f307-b7fe-461d-9703-db4d1a3458ad"),
                    CodeIso3 = "lah",
                    Name = "Lahnda"
                },
                new Language
                {
                    Id = Guid.Parse("66945f49-f8a4-4536-a879-24fdf7d59948"),
                    CodeIso3 = "lam",
                    Name = "Lamba"
                },
                new Language
                {
                    Id = Guid.Parse("22ed91eb-bb82-41c6-957e-46bf0070d8fd"),
                    CodeIso3 = "lao",
                    Name = "Lao"
                },
                new Language
                {
                    Id = Guid.Parse("54823f7a-df36-4b3f-8404-a2884cd58881"),
                    CodeIso3 = "lat",
                    Name = "Latin"
                },
                new Language
                {
                    Id = Guid.Parse("7359824c-a5a0-41f2-87dd-6774e7b2b645"),
                    CodeIso3 = "lav",
                    Name = "Latvian"
                },
                new Language
                {
                    Id = Guid.Parse("96bc282a-2896-4331-b191-f34bac82ec98"),
                    CodeIso3 = "lez",
                    Name = "Lezghian"
                },
                new Language
                {
                    Id = Guid.Parse("c38734f2-250c-4578-a852-718e87342590"),
                    CodeIso3 = "lim",
                    Name = "Limburgish"
                },
                new Language
                {
                    Id = Guid.Parse("134fb3f1-5ff2-430a-a03c-f1047bc07957"),
                    CodeIso3 = "lin",
                    Name = "Lingala"
                },
                new Language
                {
                    Id = Guid.Parse("a1fb67cc-a53e-4aed-b147-d822525fa210"),
                    CodeIso3 = "lit",
                    Name = "Lithuanian"
                },
                new Language
                {
                    Id = Guid.Parse("e4e14122-2df5-4e25-8dfb-8b106572bc6d"),
                    CodeIso3 = "lol",
                    Name = "Mongo"
                },
                new Language
                {
                    Id = Guid.Parse("8766f7a3-1ec9-49c5-975b-545aaf23188f"),
                    CodeIso3 = "loz",
                    Name = "Lozi"
                },
                new Language
                {
                    Id = Guid.Parse("cefac1d9-ee4a-4194-b5c3-c8f3a17410ec"),
                    CodeIso3 = "ltz",
                    Name = "Letzeburgesch"
                },
                new Language
                {
                    Id = Guid.Parse("609763e8-c7d4-4b2a-a1b5-7439aa89feef"),
                    CodeIso3 = "lua",
                    Name = "Luba-Lulua"
                },
                new Language
                {
                    Id = Guid.Parse("e7ee9091-70b9-48f7-a1e9-9012f816cc8c"),
                    CodeIso3 = "lub",
                    Name = "Luba-Katanga"
                },
                new Language
                {
                    Id = Guid.Parse("e1e2f4e9-1362-4883-9d75-6273d748ae2f"),
                    CodeIso3 = "lug",
                    Name = "Ganda"
                },
                new Language
                {
                    Id = Guid.Parse("982cbda4-c1ad-44c8-901b-9aded4e29ae2"),
                    CodeIso3 = "lui",
                    Name = "Luiseno"
                },
                new Language
                {
                    Id = Guid.Parse("5153e236-16a0-4c7d-867d-0042de710241"),
                    CodeIso3 = "lun",
                    Name = "Lunda"
                },
                new Language
                {
                    Id = Guid.Parse("3da8452d-490a-48b6-8b29-8e37733bcc5d"),
                    CodeIso3 = "luo",
                    Name = "Luo"
                },
                new Language
                {
                    Id = Guid.Parse("84119209-9c4d-4774-9453-08465483f7d8"),
                    CodeIso3 = "lus",
                    Name = "Lushai"
                },
                new Language
                {
                    Id = Guid.Parse("f159c16a-56f3-4e2d-98d2-d150b31f71b1"),
                    CodeIso3 = "mac",
                    Name = "Macedonian"
                },
                new Language
                {
                    Id = Guid.Parse("10ba5a12-b8de-47b9-aa5b-656ebe9e3269"),
                    CodeIso3 = "mad",
                    Name = "Madurese"
                },
                new Language
                {
                    Id = Guid.Parse("34edd63a-2519-4106-b647-9c9a4ea993a0"),
                    CodeIso3 = "mag",
                    Name = "Magahi"
                },
                new Language
                {
                    Id = Guid.Parse("598e6051-a695-4ef3-873c-d7023b16038c"),
                    CodeIso3 = "mah",
                    Name = "Marshallese"
                },
                new Language
                {
                    Id = Guid.Parse("7a615577-0a75-4e40-b39b-aa073ff092ad"),
                    CodeIso3 = "mai",
                    Name = "Maithili"
                },
                new Language
                {
                    Id = Guid.Parse("40fdb837-a5f2-4173-a168-9d077b80a153"),
                    CodeIso3 = "mak",
                    Name = "Makasar"
                },
                new Language
                {
                    Id = Guid.Parse("efbc9aaf-12f8-4219-9e84-3ae762b7fb36"),
                    CodeIso3 = "mal",
                    Name = "Malayalam"
                },
                new Language
                {
                    Id = Guid.Parse("dbadda8f-c2f5-4f51-9284-1a8dbc964cab"),
                    CodeIso3 = "man",
                    Name = "Mandingo"
                },
                new Language
                {
                    Id = Guid.Parse("1afe97b3-e272-4270-a615-af9652f0ccd4"),
                    CodeIso3 = "mao",
                    Name = "Maori"
                },
                new Language
                {
                    Id = Guid.Parse("0beb5f7d-8c79-4d9a-a9a9-04af94d2e880"),
                    CodeIso3 = "map",
                    Name = "Austronesian"
                },
                new Language
                {
                    Id = Guid.Parse("86289b72-64ed-4cf7-9c2a-c2edff5d7cf3"),
                    CodeIso3 = "mar",
                    Name = "Marathi"
                },
                new Language
                {
                    Id = Guid.Parse("3222fa14-8da1-498e-94c6-8bb30aa2908b"),
                    CodeIso3 = "mas",
                    Name = "Masai"
                },
                new Language
                {
                    Id = Guid.Parse("148ecd17-aaf7-4ca0-b625-ba294af33baf"),
                    CodeIso3 = "may",
                    Name = "Malay"
                },
                new Language
                {
                    Id = Guid.Parse("eb635210-8ff4-4b87-b6fd-db1979d8d38f"),
                    CodeIso3 = "mdf",
                    Name = "Moksha"
                },
                new Language
                {
                    Id = Guid.Parse("283cb4b4-1409-4100-98eb-d594f1eec729"),
                    CodeIso3 = "mdr",
                    Name = "Mandar"
                },
                new Language
                {
                    Id = Guid.Parse("6e92b296-895f-4055-b6eb-43ba8534dd2c"),
                    CodeIso3 = "men",
                    Name = "Mende"
                },
                new Language
                {
                    Id = Guid.Parse("05e73f52-e031-477a-90e0-831d544e81b8"),
                    CodeIso3 = "mga",
                    Name = "Irish, Middle"
                },
                new Language
                {
                    Id = Guid.Parse("ae02a2fc-fb4b-4acb-84cf-195d502773ab"),
                    CodeIso3 = "mic",
                    Name = "Micmac"
                },
                new Language
                {
                    Id = Guid.Parse("ed8e7139-704d-4501-9730-aee737630ac4"),
                    CodeIso3 = "min",
                    Name = "Minangkabau"
                },
                new Language
                {
                    Id = Guid.Parse("f5648b9e-ded2-45f3-bea1-27057ccff05e"),
                    CodeIso3 = "mis",
                    Name = "Uncoded"
                },
                new Language
                {
                    Id = Guid.Parse("06164f3b-71be-4034-ab28-9ce7d0f78d7a"),
                    CodeIso3 = "mac",
                    Name = "Macedonian"
                },
                new Language
                {
                    Id = Guid.Parse("af6c0691-7de0-4789-a7dd-a6027c7eb7a8"),
                    CodeIso3 = "mkh",
                    Name = "Mon-Khmer"
                },
                new Language
                {
                    Id = Guid.Parse("87dedc15-40c9-4129-a8ac-f31280b8efe5"),
                    CodeIso3 = "mlg",
                    Name = "Malagasy"
                },
                new Language
                {
                    Id = Guid.Parse("14fd394d-3c0f-4632-b1ba-e04b2e9ee0d2"),
                    CodeIso3 = "mlt",
                    Name = "Maltese"
                },
                new Language
                {
                    Id = Guid.Parse("52bdf580-6401-4517-8a0d-108c71deed37"),
                    CodeIso3 = "mnc",
                    Name = "Manchu"
                },
                new Language
                {
                    Id = Guid.Parse("70ccbb71-063c-4f85-b343-b69cc815ef96"),
                    CodeIso3 = "mni",
                    Name = "Manipuri"
                },
                new Language
                {
                    Id = Guid.Parse("a987a2b4-5cb1-4649-b18e-34a6d7dbd6c6"),
                    CodeIso3 = "mno",
                    Name = "Manobo"
                },
                new Language
                {
                    Id = Guid.Parse("1f62352e-f7ee-4b85-ab9b-a79497c8fc24"),
                    CodeIso3 = "moh",
                    Name = "Mohawk"
                },
                new Language
                {
                    Id = Guid.Parse("a128b46e-765e-489e-89ea-bcfa332fea8d"),
                    CodeIso3 = "mon",
                    Name = "Mongolian"
                },
                new Language
                {
                    Id = Guid.Parse("aca50fd6-e5bd-4848-965e-cbce522dd7af"),
                    CodeIso3 = "mos",
                    Name = "Mossi"
                },
                new Language
                {
                    Id = Guid.Parse("ecc9e17c-3a86-43fa-8760-4c273d51f295"),
                    CodeIso3 = "mao",
                    Name = "Maori"
                },
                new Language
                {
                    Id = Guid.Parse("edd48d8c-7910-4dda-a918-485748af148b"),
                    CodeIso3 = "may",
                    Name = "Malay"
                },
                new Language
                {
                    Id = Guid.Parse("17e8de50-a52a-4efb-83d9-08aa72e7e9ff"),
                    CodeIso3 = "mul",
                    Name = "Multiple"
                },
                new Language
                {
                    Id = Guid.Parse("9456c8bd-663b-4053-ac07-a3ddf7f46b84"),
                    CodeIso3 = "mun",
                    Name = "Munda"
                },
                new Language
                {
                    Id = Guid.Parse("a0ff8e0d-bdb6-4847-8320-6f811fcf03d9"),
                    CodeIso3 = "mus",
                    Name = "Creek"
                },
                new Language
                {
                    Id = Guid.Parse("510f9863-2fae-463c-aa20-a79cd7e70b28"),
                    CodeIso3 = "mwl",
                    Name = "Mirandese"
                },
                new Language
                {
                    Id = Guid.Parse("906bffac-daaf-49ad-8613-2fe0db1c77a8"),
                    CodeIso3 = "mwr",
                    Name = "Marwari"
                },
                new Language
                {
                    Id = Guid.Parse("e0ee0b64-6bbb-4190-b534-b1b436897d8e"),
                    CodeIso3 = "bur",
                    Name = "Burmese"
                },
                new Language
                {
                    Id = Guid.Parse("f1b18e43-7b30-4fac-8f49-e602e54f64dd"),
                    CodeIso3 = "myn",
                    Name = "Mayan"
                },
                new Language
                {
                    Id = Guid.Parse("93bba5b3-e635-4201-b802-0d2e980255cf"),
                    CodeIso3 = "myv",
                    Name = "Erzya"
                },
                new Language
                {
                    Id = Guid.Parse("53df506f-9d29-4d3d-8aec-411f918f3317"),
                    CodeIso3 = "nah",
                    Name = "Nahuatl"
                },
                new Language
                {
                    Id = Guid.Parse("e7217db6-5ed3-4141-a9ad-28ce84d81c80"),
                    CodeIso3 = "nai",
                    Name = "North American Indian"
                },
                new Language
                {
                    Id = Guid.Parse("da72e84e-5e48-418f-9109-e8dc5c46d8ba"),
                    CodeIso3 = "nap",
                    Name = "Neapolitan"
                },
                new Language
                {
                    Id = Guid.Parse("4a5152cf-57dc-4c23-9519-c88b8e545372"),
                    CodeIso3 = "nau",
                    Name = "Nauru"
                },
                new Language
                {
                    Id = Guid.Parse("a5aeea1d-d2be-45cb-af76-a03278c177f5"),
                    CodeIso3 = "nav",
                    Name = "Navaho"
                },
                new Language
                {
                    Id = Guid.Parse("48490095-03a5-40df-8de6-4a5899c8e842"),
                    CodeIso3 = "nbl",
                    Name = "South Ndebele"
                },
                new Language
                {
                    Id = Guid.Parse("4f4c183c-b199-447e-a434-6369ada7988f"),
                    CodeIso3 = "nde",
                    Name = "North Ndebele"
                },
                new Language
                {
                    Id = Guid.Parse("7f01e12c-9651-4b18-ad72-85e048364b17"),
                    CodeIso3 = "ndo",
                    Name = "Ndonga"
                },
                new Language
                {
                    Id = Guid.Parse("28135b05-00ae-4843-a3a8-a0400624b5d7"),
                    CodeIso3 = "nds",
                    Name = "Saxon, Low"
                },
                new Language
                {
                    Id = Guid.Parse("a958b6cf-fdbc-4a27-9b37-5da7a665bbe7"),
                    CodeIso3 = "nep",
                    Name = "Nepali"
                },
                new Language
                {
                    Id = Guid.Parse("e18331b4-e6fe-4e55-8af3-196ad861d632"),
                    CodeIso3 = "new",
                    Name = "Newari"
                },
                new Language
                {
                    Id = Guid.Parse("38a3429a-e331-4166-a6b9-bc40d20c41e6"),
                    CodeIso3 = "nia",
                    Name = "Nias"
                },
                new Language
                {
                    Id = Guid.Parse("f2c86489-3fbc-46b7-a39d-85eb492d5499"),
                    CodeIso3 = "nic",
                    Name = "Niger-Kordofanian"
                },
                new Language
                {
                    Id = Guid.Parse("a7b68982-b319-46df-8053-a0768d5faa87"),
                    CodeIso3 = "niu",
                    Name = "Niuean"
                },
                new Language
                {
                    Id = Guid.Parse("19e3f158-efc6-4a77-be8e-9ba93b0d1625"),
                    CodeIso3 = "dut",
                    Name = "Flemish"
                },
                new Language
                {
                    Id = Guid.Parse("8381aed5-01e7-46a0-bf30-98cb07f0033f"),
                    CodeIso3 = "nno",
                    Name = "Nynorsk, Norwegian"
                },
                new Language
                {
                    Id = Guid.Parse("efea04db-70a3-4843-a935-c74a132c3eb5"),
                    CodeIso3 = "nob",
                    Name = "Norwegian Bokmul"
                },
                new Language
                {
                    Id = Guid.Parse("b5a05884-c347-4e99-b0cb-cb333183a89f"),
                    CodeIso3 = "nog",
                    Name = "Nogai"
                },
                new Language
                {
                    Id = Guid.Parse("b6bcfdd0-c28c-4225-86e5-91a6aacbb66e"),
                    CodeIso3 = "non",
                    Name = "Norse, Old"
                },
                new Language
                {
                    Id = Guid.Parse("13b83c76-252c-47e9-a1a7-0eeb0de12178"),
                    CodeIso3 = "nor",
                    Name = "Norwegian"
                },
                new Language
                {
                    Id = Guid.Parse("6b2e70f9-026e-4178-8473-ed8d207248e8"),
                    CodeIso3 = "nqo",
                    Name = "N'Ko"
                },
                new Language
                {
                    Id = Guid.Parse("330959ee-9a4d-4281-a16b-c873d2ed3ab5"),
                    CodeIso3 = "nso",
                    Name = "Northern Sotho"
                },
                new Language
                {
                    Id = Guid.Parse("7951df9f-a7f9-4fc2-9f91-933a48f2943c"),
                    CodeIso3 = "nub",
                    Name = "Nubian"
                },
                new Language
                {
                    Id = Guid.Parse("19a77e25-f9dc-4f3b-975d-cf9f5d6ab8d4"),
                    CodeIso3 = "nwc",
                    Name = "Classical Nepal Bhasa"
                },
                new Language
                {
                    Id = Guid.Parse("284d4ae4-e9b2-4bc9-ba68-eb5396e5bd8d"),
                    CodeIso3 = "nya",
                    Name = "Nyanja"
                },
                new Language
                {
                    Id = Guid.Parse("091d2cdc-19e4-4eb8-a8f7-c544fad548cb"),
                    CodeIso3 = "nym",
                    Name = "Nyamwezi"
                },
                new Language
                {
                    Id = Guid.Parse("64ec8bd3-8331-4d77-8fca-c3f143e43762"),
                    CodeIso3 = "nyn",
                    Name = "Nyankole"
                },
                new Language
                {
                    Id = Guid.Parse("91e7ce2b-c821-479f-a405-8f37f6560149"),
                    CodeIso3 = "nyo",
                    Name = "Nyoro"
                },
                new Language
                {
                    Id = Guid.Parse("7a337071-c8b9-44ba-99f2-80be6b3eb8fd"),
                    CodeIso3 = "nzi",
                    Name = "Nzima"
                },
                new Language
                {
                    Id = Guid.Parse("7917940b-fd9c-49b5-b62b-d7914cbb779c"),
                    CodeIso3 = "oci",
                    Name = "Occitan"
                },
                new Language
                {
                    Id = Guid.Parse("3e00e818-1eb0-466b-a1a8-60839317578a"),
                    CodeIso3 = "oji",
                    Name = "Ojibwa"
                },
                new Language
                {
                    Id = Guid.Parse("6b45398a-c257-4c8f-a29a-d27caf6fbc8a"),
                    CodeIso3 = "ori",
                    Name = "Oriya"
                },
                new Language
                {
                    Id = Guid.Parse("e94959dc-2127-47cc-a179-e950a23becc3"),
                    CodeIso3 = "orm",
                    Name = "Oromo"
                },
                new Language
                {
                    Id = Guid.Parse("197ddc45-29bd-4180-bff2-b65d5a7db2b8"),
                    CodeIso3 = "osa",
                    Name = "Osage"
                },
                new Language
                {
                    Id = Guid.Parse("fcb6e4a7-6ff6-4655-bb0d-e4a5d408acb6"),
                    CodeIso3 = "oss",
                    Name = "Ossetic"
                },
                new Language
                {
                    Id = Guid.Parse("693148d6-1eb4-4d70-ba1b-789e172300e4"),
                    CodeIso3 = "ota",
                    Name = "Turkish, Ottoman"
                },
                new Language
                {
                    Id = Guid.Parse("625d02c2-09c4-44fe-8a66-782487333986"),
                    CodeIso3 = "oto",
                    Name = "Otomian"
                },
                new Language
                {
                    Id = Guid.Parse("2cd36883-190b-4b97-ade4-ce0b6c1b3a92"),
                    CodeIso3 = "paa",
                    Name = "Papuan"
                },
                new Language
                {
                    Id = Guid.Parse("64975675-dd0f-44b8-9273-397c77358c79"),
                    CodeIso3 = "pag",
                    Name = "Pangasinan"
                },
                new Language
                {
                    Id = Guid.Parse("98afa321-0da8-4ec7-9b40-6dbdec0b11e2"),
                    CodeIso3 = "pal",
                    Name = "Pahlavi"
                },
                new Language
                {
                    Id = Guid.Parse("d3ac0719-0a81-4568-a45a-b58a55424262"),
                    CodeIso3 = "pam",
                    Name = "Kapampangan"
                },
                new Language
                {
                    Id = Guid.Parse("f5adf356-95cb-41a7-b9d6-f82fe166b097"),
                    CodeIso3 = "pan",
                    Name = "Punjabi"
                },
                new Language
                {
                    Id = Guid.Parse("c9384f87-2695-43fa-9383-f5d4b9775fa3"),
                    CodeIso3 = "pap",
                    Name = "Papiamento"
                },
                new Language
                {
                    Id = Guid.Parse("529a6518-6e44-41cd-9ec3-b477515f0470"),
                    CodeIso3 = "pau",
                    Name = "Palauan"
                },
                new Language
                {
                    Id = Guid.Parse("f23052bb-dee1-451a-9813-2ccb922c5222"),
                    CodeIso3 = "peo",
                    Name = "Persian, Old"
                },
                new Language
                {
                    Id = Guid.Parse("9bf36e27-69ca-4d8d-b369-cc14964ead44"),
                    CodeIso3 = "per",
                    Name = "Persian"
                },
                new Language
                {
                    Id = Guid.Parse("905a8b24-4f90-4033-8ba9-608adeda4c0a"),
                    CodeIso3 = "phi",
                    Name = "Philippine"
                },
                new Language
                {
                    Id = Guid.Parse("48fa4b8e-8dde-4ff2-bc89-9a56ad77064e"),
                    CodeIso3 = "phn",
                    Name = "Phoenician"
                },
                new Language
                {
                    Id = Guid.Parse("faec4950-c73e-46b0-8528-627114cf4fdb"),
                    CodeIso3 = "pli",
                    Name = "Pali"
                },
                new Language
                {
                    Id = Guid.Parse("0a0bef51-cb1b-41bf-b2f7-5e881b0bd9a5"),
                    CodeIso3 = "pol",
                    Name = "Polish"
                },
                new Language
                {
                    Id = Guid.Parse("e8973daa-58ff-465b-88b3-379a3b008e9c"),
                    CodeIso3 = "pon",
                    Name = "Pohnpeian"
                },
                new Language
                {
                    Id = Guid.Parse("51dee0a4-640f-478e-b72b-5eb758e25d2b"),
                    CodeIso3 = "por",
                    Name = "Portuguese"
                },
                new Language
                {
                    Id = Guid.Parse("013827fa-868a-453b-b313-d441087771b3"),
                    CodeIso3 = "pra",
                    Name = "Prakrit"
                },
                new Language
                {
                    Id = Guid.Parse("1ee60ae9-e1b5-41c5-bb04-e7533fa281ab"),
                    CodeIso3 = "pro",
                    Name = "Occitan, Old"
                },
                new Language
                {
                    Id = Guid.Parse("770ebde4-b14e-4555-affd-d5b4f0e6f781"),
                    CodeIso3 = "pus",
                    Name = "Pashto"
                },
                new Language
                {
                    Id = Guid.Parse("c8fb0173-3339-474b-9a4e-bb9d162c8e6e"),
                    CodeIso3 = "qaa",
                    Name = "Reserved for local use"
                },
                new Language
                {
                    Id = Guid.Parse("a57e619d-f9cc-4922-bb62-5b12337bdd9a"),
                    CodeIso3 = "que",
                    Name = "Quechua"
                },
                new Language
                {
                    Id = Guid.Parse("0a4aca31-603b-40c3-b564-f81a44aae44a"),
                    CodeIso3 = "raj",
                    Name = "Rajasthani"
                },
                new Language
                {
                    Id = Guid.Parse("16b0f01d-59e2-4914-ac60-ff4ab629c0c8"),
                    CodeIso3 = "rap",
                    Name = "Rapanui"
                },
                new Language
                {
                    Id = Guid.Parse("690d6d5d-9b93-4c99-8ebd-805204699195"),
                    CodeIso3 = "rar",
                    Name = "Cook Islands Maori"
                },
                new Language
                {
                    Id = Guid.Parse("22d01984-8111-4ad9-8ea8-87a22ab018c9"),
                    CodeIso3 = "roa",
                    Name = "Romance"
                },
                new Language
                {
                    Id = Guid.Parse("530af2f3-86e4-4bbd-af88-45116947b375"),
                    CodeIso3 = "roh",
                    Name = "Romansh"
                },
                new Language
                {
                    Id = Guid.Parse("e453485c-2cfb-4a2f-8cfc-cf868a1a5587"),
                    CodeIso3 = "rom",
                    Name = "Romany"
                },
                new Language
                {
                    Id = Guid.Parse("475d9ff5-8cc8-410f-8596-919ae71a4ae1"),
                    CodeIso3 = "rum",
                    Name = "Moldovan"
                },
                new Language
                {
                    Id = Guid.Parse("11c464e1-4479-43b2-9095-a8b9bceece7a"),
                    CodeIso3 = "rum",
                    Name = "Moldovan"
                },
                new Language
                {
                    Id = Guid.Parse("7d955b40-d25d-4e86-8fa3-05a1f76ea3a2"),
                    CodeIso3 = "run",
                    Name = "Rundi"
                },
                new Language
                {
                    Id = Guid.Parse("d02e2f63-12dd-43f6-bfc6-ed013561fdf2"),
                    CodeIso3 = "rup",
                    Name = "Macedo-Romanian"
                },
                new Language
                {
                    Id = Guid.Parse("c3984d7e-f557-4e6b-9720-3e4e2a4cfc4f"),
                    CodeIso3 = "rus",
                    Name = "Russian"
                },
                new Language
                {
                    Id = Guid.Parse("2476a72b-d0c0-49d2-927d-4290a22a8227"),
                    CodeIso3 = "sad",
                    Name = "Sandawe"
                },
                new Language
                {
                    Id = Guid.Parse("a8f73a68-9ae4-474a-8d8c-ed4b2529af3a"),
                    CodeIso3 = "sag",
                    Name = "Sango"
                },
                new Language
                {
                    Id = Guid.Parse("2edb4fc5-0882-433b-a062-b7f2c25b2668"),
                    CodeIso3 = "sah",
                    Name = "Yakut"
                },
                new Language
                {
                    Id = Guid.Parse("0d83baf7-fadd-4530-b985-9d350a902b1b"),
                    CodeIso3 = "sai",
                    Name = "South American Indian"
                },
                new Language
                {
                    Id = Guid.Parse("d54e3c85-b2ea-47bc-9214-d3c833776a8c"),
                    CodeIso3 = "sal",
                    Name = "Salishan"
                },
                new Language
                {
                    Id = Guid.Parse("91e46aa6-a5d6-4736-9bcf-6d769f55b6cf"),
                    CodeIso3 = "sam",
                    Name = "Samaritan Aramaic"
                },
                new Language
                {
                    Id = Guid.Parse("2abecf7f-b99d-46fe-93ed-045b9582b8a3"),
                    CodeIso3 = "san",
                    Name = "Sanskrit"
                },
                new Language
                {
                    Id = Guid.Parse("77f1b854-9264-4fb8-97c0-29705f978071"),
                    CodeIso3 = "sas",
                    Name = "Sasak"
                },
                new Language
                {
                    Id = Guid.Parse("083bdcbb-50c7-4d09-a706-fb954107d9ef"),
                    CodeIso3 = "sat",
                    Name = "Santali"
                },
                new Language
                {
                    Id = Guid.Parse("8fa85a7f-330f-4523-959f-c05e0e23bc2c"),
                    CodeIso3 = "scn",
                    Name = "Sicilian"
                },
                new Language
                {
                    Id = Guid.Parse("63aa1451-7d8e-46f5-aa90-e10a27a4784e"),
                    CodeIso3 = "sco",
                    Name = "Scots"
                },
                new Language
                {
                    Id = Guid.Parse("ceb2e51f-f1c6-4895-b7a5-66206b9639da"),
                    CodeIso3 = "sel",
                    Name = "Selkup"
                },
                new Language
                {
                    Id = Guid.Parse("328e3336-deb5-48d6-b836-03d125f2f791"),
                    CodeIso3 = "sem",
                    Name = "Semitic"
                },
                new Language
                {
                    Id = Guid.Parse("4a22eeea-e184-456a-a5ec-0b1075aac1f3"),
                    CodeIso3 = "sga",
                    Name = "Irish, Old"
                },
                new Language
                {
                    Id = Guid.Parse("339a714c-12ac-4733-bf2e-95f6d211e098"),
                    CodeIso3 = "sgn",
                    Name = "Sign Languages"
                },
                new Language
                {
                    Id = Guid.Parse("2f89fd5b-81ca-479d-9363-a320c54e4e86"),
                    CodeIso3 = "shn",
                    Name = "Shan"
                },
                new Language
                {
                    Id = Guid.Parse("9fbfcea7-fece-4f8e-b43a-c22155cf5b96"),
                    CodeIso3 = "sid",
                    Name = "Sidamo"
                },
                new Language
                {
                    Id = Guid.Parse("90685dfa-5f6a-4f08-b071-649574ac6da2"),
                    CodeIso3 = "sin",
                    Name = "Sinhalese"
                },
                new Language
                {
                    Id = Guid.Parse("aa7b629a-b6d2-42af-881f-c6d49700fe0a"),
                    CodeIso3 = "sio",
                    Name = "Siouan"
                },
                new Language
                {
                    Id = Guid.Parse("72b51c0f-1100-4c10-b0a5-68fc4feb379e"),
                    CodeIso3 = "sit",
                    Name = "Sino-Tibetan"
                },
                new Language
                {
                    Id = Guid.Parse("f77dbed1-4740-4c8d-8718-a77c7130275d"),
                    CodeIso3 = "sla",
                    Name = "Slavic"
                },
                new Language
                {
                    Id = Guid.Parse("affa9146-8aa1-43d6-9d17-567293c7fcf9"),
                    CodeIso3 = "slo",
                    Name = "Slovak"
                },
                new Language
                {
                    Id = Guid.Parse("feeddaa0-9a9f-475b-8e52-59fc094d298e"),
                    CodeIso3 = "slo",
                    Name = "Slovak"
                },
                new Language
                {
                    Id = Guid.Parse("5733d272-62c4-4ce4-b2af-d488dba4bbe2"),
                    CodeIso3 = "slv",
                    Name = "Slovenian"
                },
                new Language
                {
                    Id = Guid.Parse("3e054145-7f53-45a4-830f-0f6fe4a3811f"),
                    CodeIso3 = "sma",
                    Name = "Southern Sami"
                },
                new Language
                {
                    Id = Guid.Parse("039e9467-ade0-455d-ac93-3d92abc24c7e"),
                    CodeIso3 = "sme",
                    Name = "Northern Sami"
                },
                new Language
                {
                    Id = Guid.Parse("d8388258-236b-4e3d-849d-3920dcf8b430"),
                    CodeIso3 = "smi",
                    Name = "Sami"
                },
                new Language
                {
                    Id = Guid.Parse("b664ea52-f10c-4833-8fa6-b52fce753fcd"),
                    CodeIso3 = "smj",
                    Name = "Lule Sami"
                },
                new Language
                {
                    Id = Guid.Parse("ef0b878e-288d-442b-a720-5a029b51f4a7"),
                    CodeIso3 = "smn",
                    Name = "Inari Sami"
                },
                new Language
                {
                    Id = Guid.Parse("0e0815e1-5926-465c-9430-7f190ca2ed3b"),
                    CodeIso3 = "smo",
                    Name = "Samoan"
                },
                new Language
                {
                    Id = Guid.Parse("d9ef7e83-b812-4aae-8dec-ad3884bd11a4"),
                    CodeIso3 = "sms",
                    Name = "Skolt Sami"
                },
                new Language
                {
                    Id = Guid.Parse("35176461-86ed-4762-a007-da653f627fb0"),
                    CodeIso3 = "sna",
                    Name = "Shona"
                },
                new Language
                {
                    Id = Guid.Parse("8b28a8b5-4d8c-4bc6-bc74-5a5e6f57d7d8"),
                    CodeIso3 = "snd",
                    Name = "Sindhi"
                },
                new Language
                {
                    Id = Guid.Parse("77fd040e-ad75-41d5-a32b-569fe425ee15"),
                    CodeIso3 = "snk",
                    Name = "Soninke"
                },
                new Language
                {
                    Id = Guid.Parse("604bc5ab-9485-4e3d-a207-6d8e70754b43"),
                    CodeIso3 = "sog",
                    Name = "Sogdian"
                },
                new Language
                {
                    Id = Guid.Parse("11a334da-21b7-4db8-81c4-d5ef7273e83b"),
                    CodeIso3 = "som",
                    Name = "Somali"
                },
                new Language
                {
                    Id = Guid.Parse("0dce1aef-4bc2-42f2-a8b0-da2e09f2266f"),
                    CodeIso3 = "son",
                    Name = "Songhai"
                },
                new Language
                {
                    Id = Guid.Parse("c7aa675e-79d6-4b29-a0cf-c4974f0016b8"),
                    CodeIso3 = "sot",
                    Name = "Sotho, Southern"
                },
                new Language
                {
                    Id = Guid.Parse("d1bc5b7b-34be-4265-af67-f3a533b656f3"),
                    CodeIso3 = "spa",
                    Name = "Castilian"
                },
                new Language
                {
                    Id = Guid.Parse("e35d4735-7a85-46c3-b603-713e12788a02"),
                    CodeIso3 = "alb",
                    Name = "Albanian"
                },
                new Language
                {
                    Id = Guid.Parse("b8584132-0af4-4e6d-8d93-2660d1880a56"),
                    CodeIso3 = "srd",
                    Name = "Sardinian"
                },
                new Language
                {
                    Id = Guid.Parse("264e91f9-9254-4219-9dc6-606d6a653afc"),
                    CodeIso3 = "srn",
                    Name = "Sranan Tongo"
                },
                new Language
                {
                    Id = Guid.Parse("b222493d-5123-4617-8d35-0a2ef9f1c01a"),
                    CodeIso3 = "srp",
                    Name = "Serbian"
                },
                new Language
                {
                    Id = Guid.Parse("5603416f-a011-4e1c-9c26-152c7516d3c8"),
                    CodeIso3 = "srr",
                    Name = "Serer"
                },
                new Language
                {
                    Id = Guid.Parse("8056accf-6b49-4adf-b705-c939ed55d730"),
                    CodeIso3 = "ssa",
                    Name = "Nilo-Saharan"
                },
                new Language
                {
                    Id = Guid.Parse("8b56ef73-fb2c-46e9-9652-59f515c57c7d"),
                    CodeIso3 = "ssw",
                    Name = "Swati"
                },
                new Language
                {
                    Id = Guid.Parse("541fbc0b-3e43-4cef-91fd-b6b81544f2c4"),
                    CodeIso3 = "suk",
                    Name = "Sukuma"
                },
                new Language
                {
                    Id = Guid.Parse("5ea17b69-f3db-4e1f-b102-1d8755f201e2"),
                    CodeIso3 = "sun",
                    Name = "Sundanese"
                },
                new Language
                {
                    Id = Guid.Parse("ab503712-1d4d-4132-9401-4daed47dfcf9"),
                    CodeIso3 = "sus",
                    Name = "Susu"
                },
                new Language
                {
                    Id = Guid.Parse("c975b8cf-c087-4140-9e1e-5a49c43adad8"),
                    CodeIso3 = "sux",
                    Name = "Sumerian"
                },
                new Language
                {
                    Id = Guid.Parse("568d3127-c263-4eda-bcd7-ccf73d94170e"),
                    CodeIso3 = "swa",
                    Name = "Swahili"
                },
                new Language
                {
                    Id = Guid.Parse("9b2417f7-710e-4356-85db-8a4b221a9d35"),
                    CodeIso3 = "swe",
                    Name = "Swedish"
                },
                new Language
                {
                    Id = Guid.Parse("30e34a79-ce6e-4fe9-868d-7bae8a5cbd4e"),
                    CodeIso3 = "syc",
                    Name = "Classical Syriac"
                },
                new Language
                {
                    Id = Guid.Parse("83ff04af-f74b-447f-9f36-92b83f1f50d3"),
                    CodeIso3 = "syr",
                    Name = "Syriac"
                },
                new Language
                {
                    Id = Guid.Parse("968bf5d8-8e58-4fb7-a46c-4e0d1604afb8"),
                    CodeIso3 = "tah",
                    Name = "Tahitian"
                },
                new Language
                {
                    Id = Guid.Parse("feda566d-c523-4ce1-9374-c9f7631e5dbe"),
                    CodeIso3 = "tai",
                    Name = "Tai"
                },
                new Language
                {
                    Id = Guid.Parse("2c82b523-5cb3-4829-8f67-6479878108e2"),
                    CodeIso3 = "tam",
                    Name = "Tamil"
                },
                new Language
                {
                    Id = Guid.Parse("63cbbe72-fdc8-4de4-936b-7a970726f852"),
                    CodeIso3 = "tat",
                    Name = "Tatar"
                },
                new Language
                {
                    Id = Guid.Parse("c1ed2d8f-cd22-4521-a1d9-bd1a3132cbe8"),
                    CodeIso3 = "tel",
                    Name = "Telugu"
                },
                new Language
                {
                    Id = Guid.Parse("88f75c89-0659-4ab1-ac20-f562b882817c"),
                    CodeIso3 = "tem",
                    Name = "Timne"
                },
                new Language
                {
                    Id = Guid.Parse("b14f3211-3baa-4c0e-a928-764111f6ce5d"),
                    CodeIso3 = "ter",
                    Name = "Tereno"
                },
                new Language
                {
                    Id = Guid.Parse("30c0a17a-aa1b-42d8-b660-935c785c09a6"),
                    CodeIso3 = "tet",
                    Name = "Tetum"
                },
                new Language
                {
                    Id = Guid.Parse("eda42610-33ee-4ad4-a4bb-724e89844783"),
                    CodeIso3 = "tgk",
                    Name = "Tajik"
                },
                new Language
                {
                    Id = Guid.Parse("d3941c60-c81a-4f62-a79f-9e2cc292d48a"),
                    CodeIso3 = "tgl",
                    Name = "Tagalog"
                },
                new Language
                {
                    Id = Guid.Parse("1e1fcb14-0106-4d74-9293-266d4e497b00"),
                    CodeIso3 = "tha",
                    Name = "Thai"
                },
                new Language
                {
                    Id = Guid.Parse("9a62d382-ba60-43ee-a51f-14d37a343d22"),
                    CodeIso3 = "tib",
                    Name = "Tibetan"
                },
                new Language
                {
                    Id = Guid.Parse("eb3f87e3-351e-49aa-bf8d-c75a88fa30d3"),
                    CodeIso3 = "tig",
                    Name = "Tigre"
                },
                new Language
                {
                    Id = Guid.Parse("ed5edbd6-2488-429c-84b3-c187b635a13f"),
                    CodeIso3 = "tir",
                    Name = "Tigrinya"
                },
                new Language
                {
                    Id = Guid.Parse("5ac8f10c-de91-44c6-be52-25945aed1450"),
                    CodeIso3 = "tiv",
                    Name = "Tiv"
                },
                new Language
                {
                    Id = Guid.Parse("ad1b7459-cb6a-4e18-9b7d-f06415e7cd96"),
                    CodeIso3 = "tkl",
                    Name = "Tokelau"
                },
                new Language
                {
                    Id = Guid.Parse("58e0e4ff-616f-4be9-990a-bb4fbbd6326a"),
                    CodeIso3 = "tlh",
                    Name = "tlhIngan-Hol"
                },
                new Language
                {
                    Id = Guid.Parse("af75d86d-5348-4b14-a473-6c773a5e74e6"),
                    CodeIso3 = "tli",
                    Name = "Tlingit"
                },
                new Language
                {
                    Id = Guid.Parse("ddccf8f2-c576-439a-8ee4-af1c6e5e2fb4"),
                    CodeIso3 = "tmh",
                    Name = "Tamashek"
                },
                new Language
                {
                    Id = Guid.Parse("2fda1152-4721-4301-9e86-4c4edd08bca4"),
                    CodeIso3 = "tog",
                    Name = "Tonga"
                },
                new Language
                {
                    Id = Guid.Parse("d5b0cb7e-a064-48c5-ac48-8b0d673c17ec"),
                    CodeIso3 = "ton",
                    Name = "Tonga"
                },
                new Language
                {
                    Id = Guid.Parse("e9f3240d-2482-49cc-bff8-a18d346c86e9"),
                    CodeIso3 = "tpi",
                    Name = "Tok Pisin"
                },
                new Language
                {
                    Id = Guid.Parse("87760ce4-2280-479a-9bb1-bb38f76a311f"),
                    CodeIso3 = "tsi",
                    Name = "Tsimshian"
                },
                new Language
                {
                    Id = Guid.Parse("3f247e23-7c66-431a-a035-9c63449ff8fe"),
                    CodeIso3 = "tsn",
                    Name = "Tswana"
                },
                new Language
                {
                    Id = Guid.Parse("3e4090c4-0d5e-4d50-b2d8-728992a4de71"),
                    CodeIso3 = "tso",
                    Name = "Tsonga"
                },
                new Language
                {
                    Id = Guid.Parse("fb6611de-f940-4f8c-8dfd-abf9dd1a13e4"),
                    CodeIso3 = "tuk",
                    Name = "Turkmen"
                },
                new Language
                {
                    Id = Guid.Parse("b2d3e194-e677-40d0-b303-82bb619a387d"),
                    CodeIso3 = "tum",
                    Name = "Tumbuka"
                },
                new Language
                {
                    Id = Guid.Parse("3118356b-1093-44db-8830-cfe04e599ab7"),
                    CodeIso3 = "tup",
                    Name = "Tupi"
                },
                new Language
                {
                    Id = Guid.Parse("3856107b-cbcd-4eae-b1aa-7de8ded21ec9"),
                    CodeIso3 = "tur",
                    Name = "Turkish"
                },
                new Language
                {
                    Id = Guid.Parse("2924570f-3df6-41b6-af20-43d6215f5c7c"),
                    CodeIso3 = "tut",
                    Name = "Altaic"
                },
                new Language
                {
                    Id = Guid.Parse("e6c9abe9-a37a-40b2-aede-4bac2d58e199"),
                    CodeIso3 = "tvl",
                    Name = "Tuvalu"
                },
                new Language
                {
                    Id = Guid.Parse("316c5c69-c667-4469-bd5e-c61823ed3274"),
                    CodeIso3 = "twi",
                    Name = "Twi"
                },
                new Language
                {
                    Id = Guid.Parse("d1ea223e-e0ff-42c3-8a2a-50823e7240c1"),
                    CodeIso3 = "tyv",
                    Name = "Tuvinian"
                },
                new Language
                {
                    Id = Guid.Parse("6429e724-6a8f-4655-bf9c-90848978b8bd"),
                    CodeIso3 = "udm",
                    Name = "Udmurt"
                },
                new Language
                {
                    Id = Guid.Parse("a7cbf44d-bd2d-4690-aa55-daeac71978f4"),
                    CodeIso3 = "uga",
                    Name = "Ugaritic"
                },
                new Language
                {
                    Id = Guid.Parse("ba2b156a-aa89-4d1d-8f0e-fb2959d993eb"),
                    CodeIso3 = "uig",
                    Name = "Uyghur"
                },
                new Language
                {
                    Id = Guid.Parse("90af6e63-4890-4e60-ab66-f2d2095c380d"),
                    CodeIso3 = "ukr",
                    Name = "Ukrainian"
                },
                new Language
                {
                    Id = Guid.Parse("71f01f88-6dbb-4c50-b614-1acd8845f82b"),
                    CodeIso3 = "umb",
                    Name = "Umbundu"
                },
                new Language
                {
                    Id = Guid.Parse("72caaee5-e9aa-4c1b-83b4-b04a7f1b5f57"),
                    CodeIso3 = "und",
                    Name = "Undetermined"
                },
                new Language
                {
                    Id = Guid.Parse("cc4618f1-8379-4548-8a0b-46aaa7e5088b"),
                    CodeIso3 = "urd",
                    Name = "Urdu"
                },
                new Language
                {
                    Id = Guid.Parse("7a8afcde-3a1b-4b01-8fa7-ccafd6849a37"),
                    CodeIso3 = "uzb",
                    Name = "Uzbek"
                },
                new Language
                {
                    Id = Guid.Parse("640a1e9b-c155-4869-9262-8fe5ed3f8610"),
                    CodeIso3 = "vai",
                    Name = "Vai"
                },
                new Language
                {
                    Id = Guid.Parse("f155608b-0469-4b3d-80df-d3ceef6ad852"),
                    CodeIso3 = "ven",
                    Name = "Venda"
                },
                new Language
                {
                    Id = Guid.Parse("f8b817b1-bc60-4212-9c7f-ad9f59bef9be"),
                    CodeIso3 = "vie",
                    Name = "Vietnamese"
                },
                new Language
                {
                    Id = Guid.Parse("25d281fe-bae8-4af9-bf91-1a704673ff60"),
                    CodeIso3 = "vol",
                    Name = "Volapuk"
                },
                new Language
                {
                    Id = Guid.Parse("88d85dbd-2247-4b6d-94b1-45269a3d5971"),
                    CodeIso3 = "vot",
                    Name = "Votic"
                },
                new Language
                {
                    Id = Guid.Parse("778346d6-b95a-4823-ba2a-c241043c9f1c"),
                    CodeIso3 = "wak",
                    Name = "Wakashan"
                },
                new Language
                {
                    Id = Guid.Parse("4d6d37a5-7c85-4805-93ee-88de62157339"),
                    CodeIso3 = "wal",
                    Name = "Wolaytta"
                },
                new Language
                {
                    Id = Guid.Parse("2ff23d88-4d58-47ea-acdb-36f699658c62"),
                    CodeIso3 = "war",
                    Name = "Waray"
                },
                new Language
                {
                    Id = Guid.Parse("d08f9690-4fe4-463a-9ca4-fca08c4594db"),
                    CodeIso3 = "was",
                    Name = "Washo"
                },
                new Language
                {
                    Id = Guid.Parse("ae508385-293a-4b01-b8a2-8eed4fd66f08"),
                    CodeIso3 = "wel",
                    Name = "Welsh"
                },
                new Language
                {
                    Id = Guid.Parse("abba4740-c0fd-4828-a3a2-ed14ee5cde6c"),
                    CodeIso3 = "wen",
                    Name = "Sorbian"
                },
                new Language
                {
                    Id = Guid.Parse("f8654c1e-ffb9-450d-9a0d-2e4c5f3b603a"),
                    CodeIso3 = "wln",
                    Name = "Walloon"
                },
                new Language
                {
                    Id = Guid.Parse("8255f33b-6b2c-4862-9e7d-febdd2ef7074"),
                    CodeIso3 = "wol",
                    Name = "Wolof"
                },
                new Language
                {
                    Id = Guid.Parse("9e047051-869b-471b-ba1d-ede5e83f330a"),
                    CodeIso3 = "xal",
                    Name = "Oirat"
                },
                new Language
                {
                    Id = Guid.Parse("cecadf2c-76b6-41bb-863f-123f934c2496"),
                    CodeIso3 = "xho",
                    Name = "Xhosa"
                },
                new Language
                {
                    Id = Guid.Parse("2edc0c66-1484-4263-befb-31e1926b3b09"),
                    CodeIso3 = "yao",
                    Name = "Yao"
                },
                new Language
                {
                    Id = Guid.Parse("a15d8eb8-240c-487c-b48a-7de61c9152c6"),
                    CodeIso3 = "yap",
                    Name = "Yapese"
                },
                new Language
                {
                    Id = Guid.Parse("a0ad3276-8a0e-4001-bfc5-476f8f69e3e7"),
                    CodeIso3 = "yid",
                    Name = "Yiddish"
                },
                new Language
                {
                    Id = Guid.Parse("85c740b5-ef6c-4cac-83ef-25535b5be082"),
                    CodeIso3 = "yor",
                    Name = "Yoruba"
                },
                new Language
                {
                    Id = Guid.Parse("066ef57c-cf11-4d59-8af0-04db74f0e60e"),
                    CodeIso3 = "ypk",
                    Name = "Yupik"
                },
                new Language
                {
                    Id = Guid.Parse("6286d0e6-1db0-41ff-8e42-2832fe3a75b9"),
                    CodeIso3 = "zap",
                    Name = "Zapotec"
                },
                new Language
                {
                    Id = Guid.Parse("f6786abd-cbc9-4b7d-b11d-51ab2d719d8f"),
                    CodeIso3 = "zbl",
                    Name = "Bliss"
                },
                new Language
                {
                    Id = Guid.Parse("99105bef-72a0-4c61-bb59-7f40ef6b3819"),
                    CodeIso3 = "zen",
                    Name = "Zenaga"
                },
                new Language
                {
                    Id = Guid.Parse("5101815a-70f2-4260-9995-7d36d2fd9465"),
                    CodeIso3 = "zgh",
                    Name = "Standard Moroccan Tamazight"
                },
                new Language
                {
                    Id = Guid.Parse("9e412c2b-fd67-4f1e-848c-0078cd74131c"),
                    CodeIso3 = "zha",
                    Name = "Chuang"
                },
                new Language
                {
                    Id = Guid.Parse("3c0304c9-20d4-413b-ba3c-3cb443e8470a"),
                    CodeIso3 = "chi",
                    Name = "Chinese"
                },
                new Language
                {
                    Id = Guid.Parse("b5af1777-6ad1-4bcd-9277-1bc5ba532c81"),
                    CodeIso3 = "znd",
                    Name = "Zande"
                },
                new Language
                {
                    Id = Guid.Parse("49cbfca2-c12e-4086-b47a-e660e9eb1bab"),
                    CodeIso3 = "zul",
                    Name = "Zulu"
                },
                new Language
                {
                    Id = Guid.Parse("8e533168-c8f6-4a3e-88a6-061858c25ea8"),
                    CodeIso3 = "zun",
                    Name = "Zuni"
                },
                new Language
                {
                    Id = Guid.Parse("aa2a286b-042c-46ef-b22a-70a53483c97b"),
                    CodeIso3 = "zxx",
                    Name = "Not applicable"
                },
                new Language
                {
                    Id = Guid.Parse("73c77272-5532-4911-adc8-7cb97e56d631"),
                    CodeIso3 = "zza",
                    Name = "Zazaki"
                }
            );
    }
}