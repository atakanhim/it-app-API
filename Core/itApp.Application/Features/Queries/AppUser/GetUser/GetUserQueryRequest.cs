﻿using MediatR;

namespace itApp.Application.Features.Queries.AppUser.GetUser
{
    public class GetUserQueryRequest : IRequest<GetUserQueryResponse>
    {
        public string UserName { get; set; }  
    }
}
