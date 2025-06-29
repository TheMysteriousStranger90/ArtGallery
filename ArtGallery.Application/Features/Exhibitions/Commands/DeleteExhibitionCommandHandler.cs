﻿using ArtGallery.Application.Contracts;
using ArtGallery.Domain.Entities;
using MediatR;

namespace ArtGallery.Application.Features.Exhibitions.Commands
{
    public class DeleteExhibitionCommandHandler : IRequestHandler<DeleteExhibitionCommand, DeleteExhibitionCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteExhibitionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteExhibitionCommandResponse> Handle(DeleteExhibitionCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteExhibitionCommandResponse();

            try
            {
                var exhibition = await _unitOfWork.Repository<Exhibition>().GetByIdAsync(request.Id);

                if (exhibition == null)
                {
                    response.Success = false;
                    response.Message = $"Exhibition with ID {request.Id} was not found.";
                    return response;
                }

                await _unitOfWork.ExecuteWithTransactionAsync(async () =>
                {
                    await _unitOfWork.Repository<Exhibition>().RemoveAsync(exhibition);
                    
                    await _unitOfWork.Complete();
                });

                response.Message = $"Exhibition '{exhibition.Title}' was successfully deleted.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred while deleting the exhibition: {ex.Message}";
            }

            return response;
        }
    }
}