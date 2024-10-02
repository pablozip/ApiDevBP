using ApiDevBP.Application.CreateUser;
using ApiDevBP.Application.DeleteUser;
using ApiDevBP.Application.GetUsers;
using ApiDevBP.Application.UpdateUser;
using ApiDevBP.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiDevBP.Controllers;

/// <summary>
/// 
/// </summary>
[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{

    protected ISender Sender => HttpContext.RequestServices.GetService<ISender>();

    /// <summary>
    /// Creación de usuario
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> SaveUser(UserModel user)
    {
        var cmd = new CreateUserCommand(user);

        var result = await Sender.Send(cmd);

        if (result > 0)
        {
            return Ok(result > 0);
        }
        else
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// Obtención de todos los usuarios
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var qry = new GetUsersQuery();

        var result = await Sender.Send(qry);

        if (result.Count > 0)
            return Ok(result);

        return NotFound();
    }

    /// <summary>
    /// Borrado de usuario en base a su Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var cmd = new DeleteUserCommand(id);
        var result = await Sender.Send(cmd);

        return Ok(result);
    }

    /// <summary>
    /// Actualización de nombre y apellido
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> UpdateUser(UserModelUpdate user)
    {
        var cmd = new UpdateUserCommand(user);
        var result = await Sender.Send(cmd);

        return Ok(result);
    }
}
