// ************************************************************************
// <copyright file="PostUserCommandHandler.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Users.PostUser
{
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using NiyaziAki.StmNatoCodingChallenge.Application.Services;

    /// <summary>
    /// Handler for creating a new user. It processes the <see cref="PostUserCommand"/> request,
    /// creates a new user, and returns a response indicating success or failure.
    /// </summary>
    public class PostUserCommandHandler : IRequestHandler<PostUserCommand, IActionResult>
    {
        private readonly IUserService userService;
        private readonly IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="PostUserCommandHandler"/> class.
        /// </summary>
        /// <param name="userService">Service used for user-related operations.</param>
        /// <param name="httpContextAccessor">Accessor for retrieving the current HTTP request context.</param>
        public PostUserCommandHandler(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            this.userService = userService;
            this.httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Handles the <see cref="PostUserCommand"/> request to create a new user.
        /// </summary>
        /// <param name="request">The request containing the user data.</param>
        /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task{IActionResult}"/> representing the result of the operation.</returns>
        public async Task<IActionResult> Handle(PostUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string newId = await this.userService.CreateNewUser(request.FullName);
                HttpRequest? requestUrl = this.httpContextAccessor.HttpContext?.Request;

                string location = $"{requestUrl?.Scheme}://{requestUrl?.Host}{requestUrl?.Path}/{newId}";
                return new CreatedResult(location, newId);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch
#pragma warning restore CA1031 // Do not catch general exception types
            {
                return new BadRequestResult();
            }
        }
    }
}
