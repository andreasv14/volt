﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volt.Application.Features.Account.Commands;
using Volt.Application.Services;

namespace Volt.WebAPI.Controllers;

/// <summary>
/// 
/// </summary>
[AllowAnonymous]
public class AccountController : ApiControllerBase
{
    /// <summary>
    /// Register as a new user
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("request")]
    public async Task<ActionResult<AuthenticationResult>> RegisterAsync([FromBody] RegisterRequest request)
    {
        return Ok(await Mediator.Send(request));
    }

    /// <summary>
    /// Login as an existing user
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpPost("login")]
    public async Task<ActionResult<AuthenticationResult>> LoginAsync(LoginRequest request)
    {
        return Ok(await Mediator.Send(request));
    }
}