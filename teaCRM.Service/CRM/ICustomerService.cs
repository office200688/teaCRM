﻿// ***********************************************************************
// Assembly         : teaCRM.Service
// Author           : Tangyouwei
// Created          : 09-13-2014
//
// Last Modified By : Tangyouwei
// Last Modified On : 09-24-2014
// ***********************************************************************
// <copyright file="ICustomerService.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using teaCRM.Entity;


/// <summary>
/// The CRM namespace.
/// </summary>
namespace teaCRM.Service.CRM
{
    /// <summary>
    /// 客户操作接口
    /// </summary>
    public interface ICustomerService
    {
        #region 筛选器接口

        /// <summary>
        /// 获取树形节点
        /// </summary>
        /// <param name="compNum">The comp number.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>List&lt;Node&gt;.</returns>
        List<Node> AsyncGetNodes(string compNum, int? id);

        #endregion

        #region 客户接口

        /// <summary>
        /// 获取客户信息列表 2014-08-29 14:58:50 By 唐有炜
        /// </summary>
        /// <param name="compNum">企业编号</param>
        /// <param name="selectFields">选择的字段（格式：new string[]{"id,cus_sname"}，id必须要有）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页的数目</param>
        /// <param name="strWhere">筛选条件（字段名="值",字段名 in (值1,值2)）</param>
        /// <param name="filedOrder">排序字段（字段名）</param>
        /// <param name="recordCount">总数</param>
        /// <returns>DataTable</returns>
        DataTable GetCustomerLsit(string compNum, string[] selectFields, int pageIndex, int pageSize,
            string strWhere, string filedOrder, out int recordCount);


        /// <summary>
        /// 获取一条客户信息
        /// </summary>
        /// <param name="compNum">The comp number.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>Dictionary&lt;System.String, System.Object&gt;.</returns>
        Dictionary<string, object> GetCustomer(string compNum, int customerId);

        /// <summary>
        /// 获取客户扩展字段信息 2014-08-29 14:58:50 By 唐有炜
        /// </summary>
        /// <param name="compNum">公司编号</param>
        /// <returns>List&lt;TFunExpand&gt;.</returns>
        List<TFunExpand> GetCustomerExpandFields(string compNum);


        /// <summary>
        /// 获取客户操作 2014-08-29 14:58:50 By 唐有炜
        /// </summary>
        /// <param name="compNum">公司编号</param>
        /// <returns>List&lt;TFunOperating&gt;.</returns>
        List<TFunOperating> GetCustomerOperating(string compNum);


        /// <summary>
        /// 添加客户信息 2014-08-30 14:58:50 By 唐有炜
        /// </summary>
        /// <param name="cusInfo">客户信息</param>
        /// <param name="cusCon">主联系人信息</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool AddCustomer(TCusBase cusInfo, TCusCon cusCon);

        /// <summary>
        /// 修改客户信息 2014-08-30 14:58:50 By 唐有炜
        /// </summary>
        /// <param name="customerId">客户id</param>
        /// <param name="cusBase">客户信息</param>
        /// <param name="cusCon">主联系人信息</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool EditCustomer(int customerId, TCusBase cusBase, TCusCon cusCon);

        /// <summary>
        /// 使用where sql语句更改客户状态(只更改主表) 2014-09-05 14:58:50 By 唐有炜
        /// </summary>
        /// <param name="strSet">要更新的字段</param>
        /// <param name="strWhere">条件</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool UpdateCustomerStatusByWhere(string strSet, string strWhere);


        /// <summary>
        /// 批量改状态
        /// </summary>
        /// <param name="cus_ids">id集合</param>
        /// <param name="op">操作（0 1）</param>
        /// <param name="field">字段</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool UpdateStatusMoreCustomer(string cus_ids, int op, string field);


        /// <summary>
        /// 使用LINQ更改客户状态（只更改主表） 2014-09-05 14:58:50 By 唐有炜
        /// </summary>
        /// <param name="fields">要更新的字段</param>
        /// <param name="predicate">条件</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool UpdateCustomerStatusByLINQ(Dictionary<string, object> fields, Expression<Func<TCusBase, bool>> predicate);

        #endregion

        #region 联系人接口

        /// <summary>
        /// 获取联系人信息列表 2014-09-01 14:58:50 By 唐有炜
        /// </summary>
        /// <param name="compNum">企业编号</param>
        /// <param name="selectFields">选择的字段（格式：new string[]{"id,cus_sname"}，id必须要有）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页的数目</param>
        /// <param name="strWhere">筛选条件（字段名="值",字段名 in (值1,值2)）</param>
        /// <param name="filedOrder">排序字段（字段名）</param>
        /// <param name="recordCount">The record count.</param>
        /// <returns>DataTable</returns>
        DataTable GetContactLsit(string compNum, string[] selectFields, int pageIndex, int pageSize,
            string strWhere, string filedOrder, out int recordCount);


        /// <summary>
        /// 获取联系人扩展字段信息 2014-08-29 14:58:50 By 唐有炜
        /// </summary>
        /// <param name="compNum">公司编号</param>
        /// <returns>联系人扩展字段</returns>
        List<TFunExpand> GetContactExpandFields(string compNum);

        /// <summary>
        /// 获取一条联系人信息
        /// </summary>
        /// <param name="compNum">The comp number.</param>
        /// <param name="conId">联系人id</param>
        /// <returns>Dictionary&lt;System.String, System.Object&gt;.</returns>
        Dictionary<string, object> GetContact(string compNum, int conId);


        /// <summary>
        /// 添加联系人 14-09-24 By 唐有炜
        /// </summary>
        /// <param name="cusId">客户id（可为空）</param>
        /// <param name="cusCon">The cus con.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool AddContact(int? cusId,TCusCon cusCon);

        /// <summary>
        /// 修改联系人  14-09-24 By 唐有炜
        /// </summary>
        /// <param name="cusCon">The cus con.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool EditContact(TCusCon cusCon);

//        /// <summary>
//        /// 删除联系人  14-09-24 By 唐有炜
//        /// </summary>
//        /// <param name="ids">The ids.</param>
//        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
//        bool DeleteContact(int ids);

        /// <summary>
        /// 更改联系人状态 2014-09-24 14:58:50 By 唐有炜
        /// </summary>
        /// <param name="ids">id集合（1,2,3）</param>
        /// <param name="status">状态（0,1）</param>
        /// <param name="field">要更新的字段</param>
        /// <returns>更新状态</returns>
        bool UpdateContactStatus(string ids, int status,string field);

        #endregion

        #region 验证接口

        /// <summary>
        /// 验证手机号是否存在
        /// </summary>
        /// <param name="cus_tel">手机号</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool ValidatePhone(string cus_tel);

        #endregion
    }
}