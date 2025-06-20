﻿using System.Linq.Expressions;
using ArtGallery.Application.Specifications.Interfaces;

namespace ArtGallery.Application.Specifications;

public class BaseSpecification<T> : ISpecification<T>
{
    public BaseSpecification()
    {
    }

    public BaseSpecification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    public Expression<Func<T, bool>> Criteria {get; }

    public List<Expression<Func<T, object>>> Includes {get; } = 
        new List<Expression<Func<T, object>>>();

    public Expression<Func<T, object>> OrderBy {get; private set;}

    public Expression<Func<T, object>> OrderByDescending {get; private set;}
    
    public Func<IQueryable<T>, IQueryable<T>> IncludeQueryBuilder { get; private set; }


    public int Take {get; private set;}

    public int Skip {get; private set;}

    public bool IsPagingEnabled {get; private set;}

    protected internal void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }
    
    protected internal void AddComplexIncludes(Func<IQueryable<T>, IQueryable<T>> includeBuilder)
    {
        IncludeQueryBuilder = includeBuilder;
    }

    protected internal void AddOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }

    protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
    {
        OrderByDescending = orderByDescExpression;
    }

    protected void ApplyPaging(int skip, int take)
    {
        Skip = skip;
        Take = take;
        IsPagingEnabled = true;
    }
}