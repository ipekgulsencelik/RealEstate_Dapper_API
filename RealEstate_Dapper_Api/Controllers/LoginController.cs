using Dapper;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_API.DTOs.LoginDTOs;
using RealEstate_Dapper_API.Tools;

namespace RealEstate_Dapper_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly Context _context;

		public LoginController(Context context)
		{
			_context = context;
		}

		[HttpPost]
		public async Task<IActionResult> SignIn(CreateLoginDTO createLoginDTO)
		{
			string user = "Select * From AppUser Where UserName=@userName and Password=@password";
			string id = "Select UserID From AppUser Where UserName=@userName and Password=@password";

			var parameters = new DynamicParameters();
			parameters.Add("@userName", createLoginDTO.UserName);
			parameters.Add("@password", createLoginDTO.Password);
			using (var connection = _context.CreateConnection())
			{
				var userValues = await connection.QueryFirstOrDefaultAsync<CreateLoginDTO>(user, parameters);
				var idValue = await connection.QueryFirstAsync<GetAppUserIdDTO>(id, parameters);

				if (userValues != null)
				{
					GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
					model.UserName = userValues.UserName;
					model.ID = idValue.UserID;
					var token = JwtTokenGenerator.GenerateToken(model);
					return Ok(token);
				}
				else
				{
					return Ok("Giriş Yapılamadı.");
				}
			}
		}
	}
}