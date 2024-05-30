using Geair.Application.Interfaces;
using Geair.Application.Mediator.Commands.UserCommands;
using Geair.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Mediator.Handlers.UserHandlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly ICloudStorageService _cloudStorageService;
        private readonly IRepository<User> _userRepository;

        public UpdateUserCommandHandler(IRepository<User> userRepository, ICloudStorageService cloudStorageService)
        {
            _userRepository = userRepository;
            _cloudStorageService = cloudStorageService;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            string storageName = "";
            string NewImageUrl = "";

            var user = await _userRepository.GetByIdAsync(request.UserId);
            user.Surname = request.Surname;
            user.Name = request.Name;
            user.Email = request.Email;
            user.Phone = request.Phone;
            if (request.ImageFile != null)
            {
                storageName = Guid.NewGuid().ToString() + "_" + request.ImageFile.FileName;
                NewImageUrl = await _cloudStorageService.UploadFileAsync(request.ImageFile, storageName);
                user.ImageUrl = NewImageUrl;
                user.ImageStorageName = storageName;
            }
            else
            {
                user.ImageUrl = request.ImageUrl;
            }
            

            await _userRepository.UpdateAsync(user);
        }
    }
}
