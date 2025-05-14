// ************************************************************************
// <copyright file="PutUserCommandHandler.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Users.PutUser
{
    using System.Threading.Tasks;
    using AutoMapper;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using NiyaziAki.StmNatoCodingChallenge.Application.Services;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Users.Models;
    using NiyaziAki.StmNatoCodingChallenge.Domain.Entities;

    /// <summary>
    /// Handler for processing the update user command. It handles updating an existing user's details.
    /// </summary>
    public class PutUserCommandHandler : IRequestHandler<PutUserCommand, IActionResult>
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PutUserCommandHandler"/> class.
        /// </summary>
        /// <param name="userService">Service for managing user operations.</param>
        /// <param name="mapper">Mapper to convert user entities to models.</param>
        public PutUserCommandHandler(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the request to update a user's details.
        /// </summary>
        /// <param name="request">The request containing the updated user information.</param>
        /// <param name="cancellationToken">Token to observe while waiting for the task to complete.</param>
        /// <returns>An <see cref="IActionResult"/> representing the result of the operation.</returns>
        public async Task<IActionResult> Handle(PutUserCommand request, CancellationToken cancellationToken)
        {
            User? user = await this.userService.Get(request.Id);
            if (user == null)
            {
                return new NotFoundResult();
            }

            user.FullName = request.FullName;
            await this.userService.Update(user);

            UserModel model = this.mapper.Map<UserModel>(user);
            ////UserModel model = UserModel.Map<UserModel>(user); same as automapper

            return new OkObjectResult(model);
        }
    }
}
