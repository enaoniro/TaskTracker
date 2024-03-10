$(document).ready(function () {
    loadDataTable();
});

function loadDataTable()
{
    dataTable = $('#myTable').DataTable({
        "ajax": {url:'/student/getall'},
        "columns": [
            { data: 'name', "width": "20" },          
            { data: 'email', "width": "20%" },
            { data: 'phone', "width": "15%" },
            { data: 'groupId', "width": "15%" },
            {
                data:'id',
                render: function (data) {
                    // Render anchor tags
                    return `<td><a href="/student/edit?id=${data}" class="btn btn-primary">Edit</a>
                        <a href="/student/delete?id=${data}" class="btn btn-danger">Delete</a></td>`;
                },
                "width": "20%"
            }
          
         
            
            
        ]
    });
}

