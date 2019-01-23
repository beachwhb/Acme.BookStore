/********************************************
 * abp.libs.datatables.createAjax是帮助ABP的动态JavaScript API代理跟Datatable的格式相适应的辅助方法.
 * abp.libs.datatables.normalizeConfiguration是另一个辅助方法.不是必须的, 但是它通过为缺少的选项提供常规值来简化数据表配置.
 * acme.bookStore.book.getList是获取书籍列表的方法
 *********************************************************************************/
$(function () {

    //可以在客户端使用服务器端定义的相同的本地化语言文本
    var l = abp.localization.getResource('BookStore');

    //创建图书
    const createModal = new abp.ModalManager(abp.appPath + 'Books/CreateModal');

    //编辑图书
    var editModal = new abp.ModalManager(abp.appPath + 'Books/EditModal');

    //获取图书列表
    const dataTable = $('#BooksTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        order: [[1, 'asc']],
        ajax: abp.libs.datatables.createAjax(acme.bookStore.book.getList),
        columnDefs: [
            {
                rowAction: {
                    items: [
                        {
                            text: l('Edit'),
                            action: function (data) {
                                editModal.open({ id: data.record.id });
                            }
                        },
                        {
                            text: l('Delete'),
                            confirmMessage: function (data) {
                                return l('BookDeletionConfirmationMessage', data.record.name);
                            },
                            action: function (data) {
                                acme.bookStore.book
                                    .delete(data.record.id)
                                    .then(function () {
                                        abp.notify.info(l('SuccessfullyDeleted'));
                                        dataTable.ajax.reload();//重新加载
                                    });
                            }
                        }
                    ]
                }
            },
            { data: 'name' },
            { data: 'type' },
            { data: 'publishDate' },
            { data: 'price' },
            { data: 'creationTime' }
        ]
    }));


    createModal.onResult(function () {
        dataTable.ajax.reload();
    });
    editModal.onResult(function () {
        dataTable.ajax.reload();
    });
    $('#NewBookButton').click(function (e) {
        e.preventDefault();//屏蔽按钮默认行为
        createModal.open();//弹出模态框
    });

    //


});