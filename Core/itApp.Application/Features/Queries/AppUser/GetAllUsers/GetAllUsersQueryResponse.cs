﻿

using itApp.Application.DTOs.User;

namespace itApp.Application.Features.Queries.AppUser.GetAllUsers
{
    public class GetAllUserQueryResponse
    {
        public IEnumerable<ListUser> Users { get; set; } // Kullanıcı listesi
        public int Page { get; set; } // İstenen sayfa numarası
        public int Size { get; set; } // Sayfa başına kullanıcı sayısı
        public int TotalCount { get; set; } // Toplam kullanıcı sayısı
    }
}
