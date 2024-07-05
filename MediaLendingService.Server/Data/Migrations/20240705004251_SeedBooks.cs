using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediaLendingService.Server.Migrations
{
    /// <inheritdoc />
    public partial class SeedBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LiteraryCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Movies" },
                    { 2, "Beauty, Jewelery & Sports" },
                    { 3, "Shoes" },
                    { 4, "Beauty" },
                    { 5, "Tools" },
                    { 6, "Books" },
                    { 7, "Outdoors" },
                    { 8, "Garden, Music & Beauty" },
                    { 9, "Clothing & Toys" },
                    { 10, "Shoes & Shoes" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CategoryId", "CoverImage", "Description", "IsCheckedOut", "Isbn", "PageCount", "PublicationDate", "Publisher", "Title" },
                values: new object[,]
                {
                    { 1, "Johnnie Schmeler", 8, "https://picsum.photos/640/480/?image=668", "Id quaerat quas incidunt. Numquam voluptatem dolores quod adipisci rerum. Ea aut non ea impedit culpa dolorum minus placeat. Dolore nobis non sint atque magnam. Alias atque ducimus corrupti quo qui enim veniam quidem. Quis at quia at facilis.", false, "0910430808773", 428, new DateOnly(2019, 2, 19), "Kunze - Bartell", "Et quasi est." },
                    { 2, "Luther O'Hara", 7, "https://picsum.photos/640/480/?image=72", "Quasi quis magnam. Sunt perspiciatis animi quasi assumenda voluptatem blanditiis porro inventore recusandae. Enim reprehenderit exercitationem aut aliquam laudantium et. Rerum dicta vel fugit recusandae dolor.", true, "9287472820386", 242, new DateOnly(2014, 7, 23), "Hodkiewicz, Gottlieb and Nicolas", "Quo odio autem." },
                    { 3, "Abigail Moore", 1, "https://picsum.photos/640/480/?image=9", "Laborum autem omnis et libero saepe cumque ipsum beatae. Nihil earum voluptates nisi quia ducimus. Voluptas quo commodi in commodi. Molestias enim omnis.", false, "5734037856167", 893, new DateOnly(2021, 10, 11), "Kunze Group", "Voluptatibus ex ut." },
                    { 4, "Susie Fahey", 7, "https://picsum.photos/640/480/?image=102", "Sunt veniam dolore omnis aliquam sed saepe rerum et cum. Dolorem in ea quia. Possimus commodi hic.", true, "4512561145060", 849, new DateOnly(2020, 4, 29), "Schumm, Tromp and Cummerata", "Magnam qui aut." },
                    { 5, "Abbie Will", 8, "https://picsum.photos/640/480/?image=298", "Praesentium consequuntur autem ab perspiciatis ad. Eaque ad eum. Nisi et tempore. Cumque laboriosam dicta et illo.", true, "2888291933201", 402, new DateOnly(2019, 3, 14), "Mueller, Wintheiser and Bradtke", "At ut non." },
                    { 6, "Willy Hahn", 2, "https://picsum.photos/640/480/?image=331", "Corrupti enim officia repudiandae voluptas reprehenderit quia. Quas dolorem hic perferendis sunt eum voluptatem. Corrupti officiis autem atque nobis delectus.", true, "7597317629855", 946, new DateOnly(2024, 5, 7), "Bauch and Sons", "Dicta ipsum fugit." },
                    { 7, "Alexane Ruecker", 1, "https://picsum.photos/640/480/?image=588", "Dolor et aut itaque quisquam saepe occaecati delectus voluptatum officiis. Autem sit quisquam. Voluptas neque nobis dignissimos architecto provident explicabo quas doloribus et.", false, "5820888622683", 197, new DateOnly(2016, 2, 29), "Bernhard LLC", "Eveniet similique minima." },
                    { 8, "Stewart Reilly", 3, "https://picsum.photos/640/480/?image=776", "Voluptatem eos ea est quia. Eos dolor eligendi. Tempora rerum et et sunt omnis.", false, "8823166410764", 293, new DateOnly(2023, 9, 15), "Wisozk and Sons", "Velit et voluptas." },
                    { 9, "Nicholaus Ratke", 7, "https://picsum.photos/640/480/?image=432", "Repellendus nihil dolor et aliquid fuga nesciunt. Temporibus facere aut. Odit exercitationem occaecati velit est. Sed natus quaerat veniam numquam molestiae quia veniam et voluptates.", true, "0401794332931", 197, new DateOnly(2017, 12, 22), "Emmerich - Metz", "At ipsam possimus." },
                    { 10, "Oliver Daugherty", 3, "https://picsum.photos/640/480/?image=1024", "Et quia magnam aperiam et. Magnam est et sed quia laborum iusto labore. Ipsam similique adipisci. Aspernatur accusamus et a aut vel quia. Culpa dolores quia dignissimos quam repellendus iure. Magnam nulla quia quisquam aliquam non id.", true, "5456745222811", 702, new DateOnly(2023, 3, 16), "Purdy, Sauer and Pacocha", "Sit ut doloremque." },
                    { 11, "Rhianna Beahan", 2, "https://picsum.photos/640/480/?image=338", "Rem ducimus rem nemo necessitatibus magni sapiente labore corporis. Quas ea ipsam. Eos et et sit aut sapiente repellat animi eveniet eum. Ut qui fugiat. Sint tenetur fuga ducimus qui fugit perferendis odit.", false, "3732229807883", 596, new DateOnly(2015, 2, 15), "Graham, Murray and Anderson", "Aut explicabo temporibus." },
                    { 12, "Branson Monahan", 6, "https://picsum.photos/640/480/?image=503", "Debitis a eos. Nulla possimus corrupti eos est suscipit maiores nam nihil. Nostrum amet laboriosam officia in non. Unde qui quidem et.", false, "4515844444638", 448, new DateOnly(2017, 2, 19), "Blick - Lehner", "Ut ut unde." },
                    { 13, "Trycia Cruickshank", 2, "https://picsum.photos/640/480/?image=750", "Non praesentium recusandae voluptas incidunt tempora omnis. Nostrum velit est tenetur fugiat qui. Qui itaque rem.", false, "3806213591017", 261, new DateOnly(2019, 10, 28), "Denesik, Walter and Keebler", "Quia pariatur adipisci." },
                    { 14, "Cheyenne Bogisich", 8, "https://picsum.photos/640/480/?image=437", "Iste dolore explicabo voluptatem quaerat totam. Voluptatem ex quis aperiam totam dolorem. Quam occaecati voluptas sit ad et nihil accusamus qui voluptatem.", true, "3477593068262", 914, new DateOnly(2022, 11, 3), "Tillman, Kassulke and Zemlak", "Ut eveniet sit." },
                    { 15, "Rosina Hodkiewicz", 10, "https://picsum.photos/640/480/?image=1048", "Vel qui aut nobis. Quasi eos et officia ab voluptas amet ut eligendi. Iusto aut vero. Esse consequatur laborum ut non ut quos.", true, "5557178450885", 475, new DateOnly(2018, 5, 13), "Roberts, Deckow and Marvin", "Porro perferendis cumque." },
                    { 16, "Laurine Zboncak", 9, "https://picsum.photos/640/480/?image=438", "Nesciunt velit rem et quam ea odit ipsum possimus. Voluptatum quo ad a neque deleniti. Alias ratione quo et quos provident quas quia. Magni animi aperiam neque officia qui illum beatae nihil. Odit sint nobis aliquid omnis. Facere cum consequatur quia qui.", false, "0966945251580", 903, new DateOnly(2018, 7, 23), "D'Amore Group", "Commodi et culpa." },
                    { 17, "Garfield Schimmel", 1, "https://picsum.photos/640/480/?image=940", "Tenetur animi id at dolores ratione nihil est in. Ullam asperiores quod id nesciunt possimus expedita eos odio. Quia aliquam sit. Eos voluptatum veniam rerum.", true, "1398838512284", 236, new DateOnly(2021, 9, 24), "Schmeler - Bernier", "Adipisci sed quo." },
                    { 18, "Darren Hermann", 10, "https://picsum.photos/640/480/?image=164", "Cumque esse in asperiores distinctio et possimus vero. Veritatis tempora porro. Est quo eum nulla nemo aut magnam dolorum.", false, "0157034938141", 194, new DateOnly(2023, 4, 9), "Streich, Batz and Hane", "Eaque dolor dolor." },
                    { 19, "Berenice Koelpin", 7, "https://picsum.photos/640/480/?image=515", "Tenetur suscipit molestiae et. Ab unde excepturi quo tenetur suscipit quod pariatur est at. Molestias rerum enim dolor itaque voluptatum. Dolores facilis ratione. Dicta est quibusdam non et sunt impedit magni pariatur quidem.", true, "8872827541323", 531, new DateOnly(2020, 8, 8), "Harber Group", "Et numquam quasi." },
                    { 20, "Aric Koepp", 6, "https://picsum.photos/640/480/?image=737", "Voluptatem rem dolorem eos rerum alias eos aperiam occaecati maiores. Perspiciatis quo neque ullam sint. Aspernatur officiis aut ut laudantium porro sed ducimus et perspiciatis. Debitis enim magnam esse similique est voluptas consequatur iste. Incidunt non at. Rerum neque quasi porro rerum ratione quos.", false, "7969401278919", 388, new DateOnly(2017, 9, 20), "Wuckert, McLaughlin and Stanton", "Autem animi consequatur." },
                    { 21, "Maia Carter", 1, "https://picsum.photos/640/480/?image=46", "Iste magni qui aut qui aliquid adipisci. Ut dolorem quisquam quae veniam laborum. Quam et facere voluptas consequatur quod molestiae. Id provident dolorem natus. Qui fugit non qui ut.", true, "6984020037366", 918, new DateOnly(2014, 9, 13), "Skiles Group", "Ea omnis et." },
                    { 22, "Tyrel Zemlak", 10, "https://picsum.photos/640/480/?image=490", "Autem debitis magnam sequi eveniet doloribus beatae. Esse omnis praesentium voluptatem. Dolor voluptate non sapiente magni deleniti totam temporibus. Unde temporibus quos voluptatem.", true, "5480531297905", 906, new DateOnly(2015, 8, 15), "Gleichner - Bernier", "Nisi omnis consequuntur." },
                    { 23, "Rose Cummerata", 5, "https://picsum.photos/640/480/?image=795", "Aut dolor unde voluptas laudantium distinctio debitis. Qui aut nisi accusamus corrupti possimus velit. Quia consequatur est ut non. Doloribus suscipit ut saepe magni et. Eligendi quam et architecto blanditiis. Quo voluptatem possimus aspernatur et veniam.", false, "6076458357274", 612, new DateOnly(2023, 2, 14), "Shields - MacGyver", "Eius aspernatur recusandae." },
                    { 24, "Katlynn Kessler", 5, "https://picsum.photos/640/480/?image=565", "Ut corrupti doloribus. Enim repellat nobis voluptatum rerum neque est. Corrupti non repellendus error vitae earum. Tempora voluptatem sapiente sint odit ut. Quia non unde dolor ad quia nisi. Suscipit provident et ipsa quia.", false, "3002666058354", 892, new DateOnly(2018, 3, 13), "Shields LLC", "Architecto sit possimus." },
                    { 25, "Timmy Cruickshank", 6, "https://picsum.photos/640/480/?image=321", "Veritatis fugit consectetur magnam omnis eaque id et. Quia autem quis. Qui ducimus sed et non aut nam quasi. Quos doloremque delectus et dignissimos laudantium facilis nobis ut. Maxime repellendus quia delectus consequatur eaque. Quidem officiis amet et iste non minima non perferendis.", true, "2612852234953", 897, new DateOnly(2022, 4, 23), "Luettgen, Zulauf and Beier", "Maxime officiis voluptatum." },
                    { 26, "Anthony Konopelski", 7, "https://picsum.photos/640/480/?image=644", "Ad itaque aspernatur nobis quo molestiae dolorem necessitatibus magni ut. Cupiditate sed eaque nisi est. Sit ipsa id ut fugit magni reiciendis id quia. Vel dignissimos tempore non mollitia molestiae nihil perferendis est. Mollitia consequuntur neque. Voluptas quaerat cupiditate.", true, "1041918193636", 502, new DateOnly(2023, 2, 11), "Paucek Inc", "Deleniti enim aut." },
                    { 27, "Jesse Bailey", 9, "https://picsum.photos/640/480/?image=152", "Nesciunt necessitatibus aut et rerum vero est. Quisquam rerum provident cum dolor unde. Ipsum labore autem pariatur aut itaque est quod quos placeat. Et omnis eum et amet velit atque beatae delectus neque. Est enim nemo velit quod incidunt placeat.", true, "7176513770051", 819, new DateOnly(2018, 7, 31), "Orn, Ullrich and Botsford", "Ut voluptas aspernatur." },
                    { 28, "Kristina Ratke", 2, "https://picsum.photos/640/480/?image=528", "Occaecati perspiciatis nobis velit quam doloribus aliquid. Numquam eveniet praesentium. Veritatis deleniti voluptatem quo. Praesentium perferendis sequi earum sint aliquam. Amet et exercitationem aut.", true, "6040106515378", 977, new DateOnly(2021, 5, 24), "Hand, Hoeger and Windler", "Suscipit consectetur cumque." },
                    { 29, "Maybelle Kreiger", 1, "https://picsum.photos/640/480/?image=538", "Quis sed perferendis. Optio perspiciatis qui magnam in beatae enim placeat exercitationem reprehenderit. Doloribus quis at fugit ut aut aspernatur. Et eligendi quia quos aut cumque velit. Corrupti nihil dolor nisi omnis et aut laudantium.", true, "9698278330199", 231, new DateOnly(2019, 5, 17), "Greenfelder LLC", "Deleniti voluptatem quia." },
                    { 30, "Kasey Hirthe", 9, "https://picsum.photos/640/480/?image=222", "Ipsa sed quae quasi iste ut iure et dolor. Sint eaque qui impedit rerum similique sequi molestiae. Eum consequuntur consequatur ratione voluptatem error. Consequatur sunt dignissimos excepturi maxime.", true, "7744713693571", 532, new DateOnly(2018, 11, 20), "Gibson Group", "Autem ab in." },
                    { 31, "Magdalen Padberg", 3, "https://picsum.photos/640/480/?image=852", "Quas ut praesentium ullam ipsum nam itaque enim non natus. Beatae eligendi quis nihil sapiente quis vel quia autem. Dolorum sapiente modi ea delectus sunt. Ad sed animi ut deserunt voluptatibus minima. Accusantium nesciunt sunt dolores velit ea. Voluptas illum et.", true, "4148329253038", 962, new DateOnly(2022, 6, 23), "Johns Group", "Quia non sunt." },
                    { 32, "Demetris Weber", 4, "https://picsum.photos/640/480/?image=1003", "Quo vel sed animi velit ea nihil dolor ipsa. Enim suscipit quia quibusdam. Similique reprehenderit voluptatem temporibus eius commodi.", true, "1091094772217", 848, new DateOnly(2016, 6, 4), "Hane LLC", "Corrupti quo sunt." },
                    { 33, "Mohammed Beer", 1, "https://picsum.photos/640/480/?image=427", "Beatae ratione cumque aut ratione asperiores dignissimos repellendus. Quibusdam aut iure dicta perspiciatis. Vitae ipsa minima. At ipsa laborum enim odit. Sapiente voluptatibus suscipit.", false, "9208909543777", 722, new DateOnly(2018, 4, 23), "Miller, Marks and Daniel", "Doloremque provident odit." },
                    { 34, "Michel Satterfield", 6, "https://picsum.photos/640/480/?image=992", "Officiis deserunt inventore sit perferendis aut. Exercitationem velit ea numquam laudantium praesentium. Qui reiciendis reprehenderit nisi. Architecto aspernatur est autem voluptas numquam nostrum esse rerum. Voluptatem at qui sapiente dolorum ab nam consequatur cumque maiores.", false, "2276003953171", 756, new DateOnly(2015, 5, 29), "Ernser - Gutkowski", "Ducimus et ducimus." },
                    { 35, "Gabriel Beahan", 1, "https://picsum.photos/640/480/?image=92", "Quas voluptas magni sequi ut est ea sint dolores. Rem rerum dolorem recusandae inventore tempore voluptatem quo explicabo atque. Vel quaerat hic et minima minus. Eius consequuntur pariatur aliquam commodi. Omnis reprehenderit est totam fugit consequatur aut aperiam.", true, "6015903151265", 961, new DateOnly(2015, 6, 25), "Murphy - Volkman", "Est eligendi ducimus." },
                    { 36, "Curtis Ledner", 10, "https://picsum.photos/640/480/?image=877", "Libero veritatis pariatur quisquam. Rem velit exercitationem est voluptatem tenetur autem optio. Velit repellat ipsam corporis exercitationem corporis expedita.", false, "3744378992822", 634, new DateOnly(2020, 5, 21), "Davis - Jones", "Optio quis doloremque." },
                    { 37, "Ettie Hamill", 10, "https://picsum.photos/640/480/?image=911", "Dolores quis porro sint tempora voluptas et. Harum libero ullam enim natus architecto culpa quia et. Dolorum qui animi et porro quas architecto. Laboriosam dolorem alias similique voluptas aut sequi voluptate.", true, "3136590824973", 729, new DateOnly(2022, 11, 3), "Rippin - Kunze", "Eum consequatur eos." },
                    { 38, "Cory Spinka", 6, "https://picsum.photos/640/480/?image=338", "Cum vero et dolorem velit nesciunt sequi. Ut qui velit reprehenderit. Dignissimos laudantium sint odit asperiores nesciunt tempore qui. Excepturi laborum et ea quo quas qui. Cupiditate et facilis velit cumque minima aliquam repellendus.", false, "3994352680034", 507, new DateOnly(2015, 6, 28), "Terry, O'Keefe and Ankunding", "Et aliquam expedita." },
                    { 39, "Mable Lowe", 1, "https://picsum.photos/640/480/?image=872", "Placeat nostrum quod amet distinctio voluptatem soluta ea autem. Error laborum quasi soluta voluptate quisquam veritatis dolore eos. Ut autem ea animi recusandae.", false, "4876722625205", 328, new DateOnly(2022, 4, 3), "Leannon and Sons", "Autem dignissimos et." },
                    { 40, "Gerard Reinger", 5, "https://picsum.photos/640/480/?image=889", "Velit placeat repellendus a non qui. Vero exercitationem neque explicabo similique. Aspernatur assumenda veniam ipsa impedit totam consequatur similique voluptates. Est minus odit et velit quam earum dolores qui. Animi illo sunt alias soluta est aut repellat.", true, "9106278590289", 168, new DateOnly(2019, 11, 28), "Hintz, Dickens and Kuhn", "Minus eum vitae." },
                    { 41, "Joey Waters", 1, "https://picsum.photos/640/480/?image=600", "Cum veniam commodi. Ex consequatur placeat reiciendis in et et est et ut. Et blanditiis voluptas vero voluptas.", false, "9353652328673", 913, new DateOnly(2015, 1, 12), "Turcotte and Sons", "Iusto aliquid doloremque." },
                    { 42, "Layla Wuckert", 6, "https://picsum.photos/640/480/?image=250", "Qui fugit ducimus sunt sit architecto. Quos error vel voluptates doloribus quia. Consequatur in illo illum est eum labore rerum et.", true, "3475121744886", 751, new DateOnly(2024, 3, 13), "Jones, Towne and Parisian", "Vitae occaecati culpa." },
                    { 43, "Baylee Raynor", 10, "https://picsum.photos/640/480/?image=64", "Dolor exercitationem autem non officiis et eius. Omnis sit placeat laudantium doloremque beatae iusto eius minus. Aspernatur ut veniam voluptatem sed unde laboriosam tempora.", true, "9051932699726", 176, new DateOnly(2016, 8, 23), "Windler - Spencer", "Voluptas facere culpa." },
                    { 44, "Kailee Stamm", 1, "https://picsum.photos/640/480/?image=1078", "Vero et praesentium sunt dolore accusamus est. Facere saepe sint in temporibus omnis sit. Aliquam labore ea dolores ducimus aliquid commodi. Ut laudantium et provident cumque eos molestiae.", true, "0755010892861", 820, new DateOnly(2016, 10, 27), "Heaney - Bechtelar", "Eligendi ea voluptas." },
                    { 45, "Chadrick Kuvalis", 8, "https://picsum.photos/640/480/?image=925", "Amet repellendus delectus sed vero et laudantium molestiae ut dignissimos. Magnam quas neque excepturi pariatur eveniet aliquid. Laboriosam voluptas alias neque. Vero eveniet veritatis. Quas error dolorem unde. Dolor ut rerum perspiciatis atque labore unde natus saepe non.", true, "6983511692954", 400, new DateOnly(2015, 5, 30), "Jones - Gulgowski", "Exercitationem corrupti eos." },
                    { 46, "Forest Hansen", 4, "https://picsum.photos/640/480/?image=463", "Nemo esse fugit facilis omnis accusamus quasi. Facilis iusto id voluptatem ut. Mollitia ut ut aliquid veritatis porro quia id modi. Asperiores tempora voluptatum cupiditate in.", false, "5767213283495", 599, new DateOnly(2022, 5, 2), "Wisozk LLC", "Voluptate minima tenetur." },
                    { 47, "Dillon Little", 8, "https://picsum.photos/640/480/?image=644", "Consectetur quo est omnis qui perspiciatis id numquam. Harum quas magni provident quae quidem. Deserunt vel id perferendis nemo ea molestiae.", true, "0719638028552", 172, new DateOnly(2018, 1, 27), "Waelchi LLC", "Non porro aut." },
                    { 48, "Alaina Ruecker", 3, "https://picsum.photos/640/480/?image=1044", "Esse qui earum tempora. Repellendus voluptates illo enim voluptatum eum. Quas quia non. Sequi et nobis voluptas perspiciatis eum.", false, "6389356217251", 964, new DateOnly(2014, 11, 22), "Kihn Inc", "Quisquam eveniet vero." },
                    { 49, "Javonte Marvin", 5, "https://picsum.photos/640/480/?image=633", "Dolores cumque sed beatae non id aperiam corrupti et. Quia qui impedit ex non in officiis quod rerum. Tempore ut voluptate tempore odit aut in atque.", false, "2678896729077", 326, new DateOnly(2016, 2, 4), "Windler LLC", "Eveniet vel quod." },
                    { 50, "Mylene Murray", 8, "https://picsum.photos/640/480/?image=669", "Voluptatem exercitationem dignissimos. Quisquam accusantium unde ut laborum qui cupiditate voluptatibus ullam sequi. Autem repellat sint maiores. Et reiciendis ducimus.", false, "4204293391906", 878, new DateOnly(2019, 4, 26), "Luettgen - Wisoky", "Delectus aut et." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "LiteraryCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LiteraryCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LiteraryCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LiteraryCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LiteraryCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "LiteraryCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "LiteraryCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "LiteraryCategories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "LiteraryCategories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "LiteraryCategories",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
