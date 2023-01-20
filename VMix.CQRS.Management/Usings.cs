﻿global using System.Text;
global using MediatR;
global using VMix.Data.Abstractions;
global using VMix.Data.Entities;
global using AutoMapper;
global using VMix.Data.Extensions;
global using VMix.CQRS.Contracts.UserContracts;
global using Microsoft.IdentityModel.Tokens;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using Microsoft.Extensions.Configuration;
global using VMix.CQRS.QueryRequests.UserQueryRequest;
global using VMix.CQRS.CommandRequests.AuthCommandRequests;
global using VMix.CQRS.CommandRequests.UserCommandRequests;
global using VMix.CQRS.Contracts.PermissionContracts;
global using VMix.CQRS.Contracts.AuthContracts;
global using VMix.CQRS.QueryRequests.NavMenuQueryRequest;
global using VMix.CQRS.Contracts.NavMenuContracts;
global using VMix.CQRS.Contracts.RoleContracts;
global using VMix.CQRS.QueryRequests.RoleQueryRequests;
global using VMix.CQRS.CommandRequests.RoleCommandRequests;
