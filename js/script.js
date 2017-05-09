jQuery(document).ready(function ($) {
   
        $('.datatable').dataTable({
            "language": {
                
	                "sProcessing":   "جاري التحميل...",
                    "sLengthMenu":   "أظهر مدخلات _MENU_",
                    "sZeroRecords":  "لم يُعثر على أية سجلات",
                    "sInfo":         "إظهار _START_ إلى _END_ من أصل _TOTAL_ مدخل",
                    "sInfoEmpty":    "يعرض 0 إلى 0 من أصل 0 سجلّ",
                    "sInfoFiltered": "(منتقاة من مجموع _MAX_ مُدخل)",
                    "sInfoPostFix":  "",
                    "sSearch":       "ابحث:",
                    "sUrl":          "",
                    "oPaginate": {
                        "sFirst":    "الأول",
                        "sPrevious": "السابق",
                        "sNext":     "التالي",
                        "sLast":     "الأخير"
                    }
                },
           
           
           
            "bDestroy": true,
            "pageLength": 25,
            "bLengthChange": false,
            "columnDefs":
          [
               { "searchable": true, "targets": 0 },
               { "searchable": true, "targets": 1 },
               { "searchable": true, "targets": 2 },
              {
              'orderable': true,
              'targets': 0

          }
          ]

        });
        $('.datatable4').dataTable({
            "language": {

                "sProcessing": "جاري التحميل...",
                "sLengthMenu": "أظهر مدخلات _MENU_",
                "sZeroRecords": "لم يُعثر على أية سجلات",
                "sInfo": "إظهار _START_ إلى _END_ من أصل _TOTAL_ مدخل",
                "sInfoEmpty": "يعرض 0 إلى 0 من أصل 0 سجلّ",
                "sInfoFiltered": "(منتقاة من مجموع _MAX_ مُدخل)",
                "sInfoPostFix": "",
                "sSearch": "ابحث:",
                "sUrl": "",
                "oPaginate": {
                    "sFirst": "الأول",
                    "sPrevious": "السابق",
                    "sNext": "التالي",
                    "sLast": "الأخير"
                }
            },



            "bDestroy": true,
            "pageLength": 25,
            "bLengthChange": false,
            "columnDefs":
          [
              { "searchable": true, "targets": 0 },
               { "searchable": true, "targets": 1 },
                { "searchable": true, "targets": 2 },
                { "searchable": true, "targets": 3 },
              {
                  'orderable': true,
                  'targets': 0

              }
          ]

        });


        $('.datatable_nosearch').dataTable({
            "language": {

                "sProcessing": "جاري التحميل...",
                "sLengthMenu": "أظهر مدخلات _MENU_",
                "sZeroRecords": "لم يُعثر على أية سجلات",
                "sInfo": "إظهار _START_ إلى _END_ من أصل _TOTAL_ مدخل",
                "sInfoEmpty": "يعرض 0 إلى 0 من أصل 0 سجلّ",
                "sInfoFiltered": "(منتقاة من مجموع _MAX_ مُدخل)",
                "sInfoPostFix": "",
                "sSearch": "ابحث:",
                "sUrl": "",
                "oPaginate": {
                    "sFirst": "الأول",
                    "sPrevious": "السابق",
                    "sNext": "التالي",
                    "sLast": "الأخير"
                }
            },
            "pageLength": 25,
            "bLengthChange": false,
            "bDestroy": true,
            "searching": false,
            "columnDefs":
          [
          {
              'orderable': true,
              'targets': 0

          }
          ]

        });

       
     $(function () {
         $('#ServicesList').change(function () {
             window.location = "/GeneralAids/Index?serviceid=" + $(this).val();
         });
     });
       
     $('.disabledform .form-control').attr('disabled', true).attr('readonly', true);
     $('.disabledform .check-box').attr('disabled', true).attr('readonly', true);
    }
);