using TranVanThanh_2122110005.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;

namespace TranVanThanh_2122110005.Model
{
    public class Post
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; } = "system";
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }

    public static class PostEndpoints
    {
        public static void MapPostEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/Post").WithTags(nameof(Post));

            group.MapGet("/", async (AppDbContext db) =>
            {
                return await db.Posts.ToListAsync();
            })
            .WithName("GetAllPosts")
            .WithOpenApi();

            group.MapGet("/{id}", async Task<Results<Ok<Post>, NotFound>> (int id, AppDbContext db) =>
            {
                return await db.Posts.AsNoTracking()
                    .FirstOrDefaultAsync(post => post.Id == id)
                    is Post post
                        ? TypedResults.Ok(post)
                        : TypedResults.NotFound();
            })
            .WithName("GetPostById")
            .WithOpenApi();

            group.MapPost("/", async (Post post, AppDbContext db) =>
            {
                db.Posts.Add(post);
                await db.SaveChangesAsync();
                return TypedResults.Created($"/api/Post/{post.Id}", post);
            })
            .WithName("CreatePost")
            .WithOpenApi();

            group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Post updatedPost, AppDbContext db) =>
            {
                var affected = await db.Posts
                    .Where(p => p.Id == id)
                    .ExecuteUpdateAsync(setters => setters
                        .SetProperty(p => p.Title, updatedPost.Title)
                        .SetProperty(p => p.Content, updatedPost.Content)
                        .SetProperty(p => p.UpdatedAt, DateTime.UtcNow)
                        .SetProperty(p => p.UpdatedBy, updatedPost.UpdatedBy)
                    );
                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("UpdatePost")
            .WithOpenApi();

            group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, AppDbContext db) =>
            {
                var affected = await db.Posts
                    .Where(p => p.Id == id)
                    .ExecuteDeleteAsync();
                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("DeletePost")
            .WithOpenApi();
        }
    }
}
