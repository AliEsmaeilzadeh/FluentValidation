using Paraph_Food.Application.Common;
using Paraph_Food.Application.Context;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Common.Exceptions;
using Paraph_Food.Domain.Enities.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using static Paraph_Food.Domain.Enums.Enums;

namespace Paraph_Food.Application.Services.Products.Commands.SetProductScoreService
{
    public class SetProductScoreService : ISetProductScoreService
    {
        private readonly IParaph_DbContext _db;
        public SetProductScoreService(IParaph_DbContext db)
        {
            _db = db;
        }
        public async Task<CommandResultDto> ExecuteAsync(long userId, int productId, double score)
        {
			try
			{
                if (score < 0 || score > 5)
                    throw new MyException(ErrorMessages.InValidInputsException);

                var user = await _db.Users.FindAsync(userId);
                if (user == null)
                    throw new MyException(ErrorMessages.NoUserException);
                else if (user.UserStatus == UserStatus.Disabled)
                    throw new MyException(ErrorMessages.UserIsDisabledException);
                else if (user.UserStatus == UserStatus.Blocked)
                    throw new MyException(ErrorMessages.UserIsBlockedException);


                var product = await _db.Products.FindAsync(productId);
                if (product == null)
                    throw new MyException(ErrorMessages.NotFoundProductException);

                var productScore = await _db.ProductScores.FindAsync(productId, userId);
                
                // اگر خالی باشد امتیاز جدید ثبت میکنیم
                if(productScore == null)
                {
                    await _db.ProductScores.AddAsync(new ProductScore()
                    {
                        ProductId = productId,
                        UserId = userId,
                        Score = score,
                    });
                    await _db.SaveChangesAsync();
                }
                // اگر خالی نباشد امتیاز قبلی کاربر را ویرایش می کنیم
                else
                {
                    productScore.Score = score;
                    await _db.SaveChangesAsync();
                }

                return new CommandResultDto()
                {
                    IsSuccess = true
                };
			}
            catch (MyException ex)
            {
                return new CommandResultDto()
                {
                    IsSuccess = false,
                    Exception = new ErrorDto(ex)
                };
            }
            catch (Exception ex)
			{
                return new CommandResultDto()
                {
                    IsSuccess = false,
                    Exception = new ErrorDto(ex)
                };
			}
        }
    }
}
