// ************************************************************************
// <copyright file="TransactionProfile.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Transactions.Profiles
{
    using AutoMapper;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Transactions.Models;
    using NiyaziAki.StmNatoCodingChallenge.Domain.Entities;

    /// <summary>
    /// AutoMapper profile for mapping between <see cref="Transaction"/> entity and <see cref="TransactionModel"/> DTO.
    /// </summary>
    public class TransactionProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionProfile"/> class.
        /// Defines the mapping configuration from <see cref="Transaction"/> to <see cref="TransactionModel"/>.
        /// This constructor is automatically called by AutoMapper during startup to register the mapping rules.
        /// </summary>
        public TransactionProfile()
        {
            this.CreateMap<Transaction, TransactionModel>()
                .ForMember(model => model.Id, config => config.MapFrom(entity => entity.Id))
                .ForMember(model => model.UserId, config => config.MapFrom(entity => entity.UserId))
                .ForMember(model => model.Amount, config => config.MapFrom(entity => entity.Amount))
                .ForMember(model => model.TransactionType, config => config.MapFrom(entity => entity.TransactionType))
                .ForMember(model => model.CreatedAt, config => config.MapFrom(entity => entity.CreatedAt));
        }
    }
}
