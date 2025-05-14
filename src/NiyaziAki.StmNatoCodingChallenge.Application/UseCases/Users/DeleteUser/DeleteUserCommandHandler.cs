// ************************************************************************
// <copyright file="DeleteUserCommandHandler.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Users.DeleteUser
{
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using NiyaziAki.StmNatoCodingChallenge.Application.Services;
    using NiyaziAki.StmNatoCodingChallenge.Domain.Entities;

    /// <summary>
    /// Handler for the DeleteUserCommand. This class processes the command to delete a user and their associated transactions.
    /// </summary>
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, IActionResult>
    {
        private readonly IUserService userService;
        private readonly ITransactionService transactionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteUserCommandHandler"/> class.
        /// </summary>
        /// <param name="userService">Service for user-related operations, such as fetching and deleting users.</param>
        /// <param name="transactionService">Service for transaction-related operations, such as deleting transactions associated with a user.</param>
        public DeleteUserCommandHandler(IUserService userService, ITransactionService transactionService)
        {
            this.userService = userService;
            this.transactionService = transactionService;
        }

        /// <summary>
        /// Handles the deletion of a user and their associated transactions.
        /// </summary>
        /// <param name="request">The command containing the user ID to delete.</param>
        /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the operation (e.g., success or not found).</returns>
        public async Task<IActionResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            User? user = await this.userService.Get(request.Id);

            if (user == null)
            {
                return new NotFoundResult();
            }

            if (user.Transactions != null && user.Transactions.Any())
            {
                await this.transactionService.Delete(user.Transactions);
            }

            await this.userService.Delete(user);

            return new OkResult();
        }
    }
}
