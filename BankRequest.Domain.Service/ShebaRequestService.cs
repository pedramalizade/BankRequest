﻿using BankRequest.Domain.Core.Contracts.Repository;
using BankRequest.Domain.Core.Contracts.Service;
using BankRequest.Domain.Core.DTOs;
using BankRequest.Domain.Core.Entites;
using BankRequest.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankRequest.Domain.Service
{
    public class ShebaRequestService: IShebaRequestService
    {
        private readonly IShebaRequestRepository _repository;

        public ShebaRequestService(IShebaRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> CreateRequestAsync(ShebaRequestDto dto, CancellationToken cancellationToken)
        {
            try
            {
                var request = new ShebaRequest
                {
                    Price = dto.Price,
                    FromShebaNumber = dto.FromShebaNumber,
                    ToShebaNumber = dto.ToShebaNumber,
                    Note = dto.Note
                };

                var saved = await CreateAsync(request, cancellationToken);
                return new
                {
                    message = "درخواست با موفقیت ذخیره شد و در وضعیت در انتظار قرار دارد",
                    request = saved
                };
            }
            catch (Exception ex)
            {
                return new { message = ex.Message, code = "400" };
            }
        }

        public async Task<ShebaRequest> CreateAsync(ShebaRequest request, CancellationToken cancellationToken)
        {
            if (!Regex.IsMatch(request.FromShebaNumber, @"^IR\d{22}$") ||
                !Regex.IsMatch(request.ToShebaNumber, @"^IR\d{22}$"))
            {
                throw new Exception("شماره شبا نامعتبر است");
            }

            if (request.Price <= 0)
            {
                throw new Exception("مبلغ درخواست باید بیشتر از صفر باشد");
            }

            var account = await _repository.GetAccountByShebaNumberAsync(request.FromShebaNumber, cancellationToken);
            if (account == null)
            {
                throw new Exception("حساب مرتبط با شماره شبا یافت نشد");
            }

            if (request.Price > account.AvailableBalance)
            {
                throw new Exception("مبلغ درخواست بیشتر از موجودی قابل برداشت است");
            }

            await _repository.AddAsync(request, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
            return request;
        }

        public async Task<List<ShebaRequest>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(cancellationToken);
        }

        public async Task<ShebaRequest?> UpdateStatusAsync(int id, RequestStatus status, string note, CancellationToken cancellationToken)
        {
            var updatedRequest = await _repository.UpdateStatusAsync(id, status, note, cancellationToken);
            if (updatedRequest == null)
            {
                throw new Exception("درخواست با شناسه مورد نظر یافت نشد");
            }
            return updatedRequest;
        }
    }
}
