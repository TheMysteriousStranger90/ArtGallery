﻿namespace ArtGallery.Application.DTOs;

public class PaintingImageDto
{
    public Guid Id { get; set; }
    public string PictureUrl { get; set; }
    public bool IsMain { get; set; }
    public string PublicId { get; set; }
}