// ************************************************************************
// <copyright file="UserProfile.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Users.Profiles
{
    using AutoMapper;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Users.Models;
    using NiyaziAki.StmNatoCodingChallenge.Domain.Entities;

    /// <summary>
    /// AutoMapper profile for mapping between <see cref="User"/> entity and <see cref="UserModel"/> DTO.
    /// </summary>
    public class UserProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfile"/> class.
        /// Defines the mapping configuration from <see cref="User"/> to <see cref="UserModel"/>.
        /// This constructor is automatically called by AutoMapper during startup to register the mapping rules.
        /// </summary>
        public UserProfile()
        {
            this.CreateMap<User, UserModel>()
                .ForMember(model => model.Id, config => config.MapFrom(entity => entity.Id))
                .ForMember(model => model.FullName, config => config.MapFrom(entity => entity.FullName));
        }
    }
}
