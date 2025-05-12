// ************************************************************************
// <copyright file="BaseController.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// A base controller class that provides common functionality for all API controllers.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : Controller
    {
    }
}
