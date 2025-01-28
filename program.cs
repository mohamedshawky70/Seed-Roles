//كانت AddDefaultIdentity<IdentityUser>
//وانت هتستخدم الأيدنتتي رول تحت كبارمتر فلازم تضيفها هنا
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddDefaultUI() //identity page download with default identity by default
	.AddDefaultTokenProviders(); // To forget passowrd

// Call tow method when program start local or publisher
//Start to send rolManager and userManger as parameter
var scopFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using var scop = scopFactory.CreateScope();
var rolManager = scop.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
var userManager = scop.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
//End to send rolManager and userManger as parameter
// Call tow method when program start local or publisher
await DefaultRoles.SeedRolesAsync(rolManager);
await DefaultUsers.SeedAdminUserAsync(userManager);
