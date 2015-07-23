$(document).ready(function () {
	var lstnhomChiTieu = GetDataCallMethordWithAjax("/Grid/GetListNhomChiTieu", null);
	var lstDoiTuong;
	var lstChiTieu;
	var dataFill;
	if (lstnhomChiTieu != null && lstnhomChiTieu.length > 0) {
		var cbxNhomChiTieu = document.getElementById("cbxNhomChiTieu");
		for (var i = 0; i < lstnhomChiTieu.length; i++) {
			var option = document.createElement("option");
			option.text = lstnhomChiTieu[i].Title;
			option.value = lstnhomChiTieu[i].Id;
			cbxNhomChiTieu.add(option);
		}
		
		lstDoiTuong = GetListDoiTuong();
		
		var Nhom_Id = { Nhom_Id: 0 };
		lstChiTieu = GetDataCallMethordWithAjax("/Grid/GetListChiTieu", Nhom_Id);

		dataFill = GetDataFoGrid(lstChiTieu, lstDoiTuong);
		BuildGridIncludeTopHeaderAndLeftHeader(lstChiTieu, lstDoiTuong, dataFill, null, "row", 970);
	}

	$("#btnChuyen").click(function () {
		var dataInputLstChiTieu = { lstChiTieu: JSON.stringify(lstChiTieu) };
		var dataUnit = GetDataCallMethordWithAjax("/Grid/GetUnitFollowListChiTieu", dataInputLstChiTieu);
		$("#example1").empty();
		if ($("#btnChuyen").val() == "Chuyển Menu") {
			var value = { lstChiTieu_Id: JSON.stringify(lstChiTieu), lstDoiTuong_Id: JSON.stringify(lstDoiTuong) };
			dataFill = GetDataCallMethordWithAjax("/Grid/GetListThongKe2", value);
			BuildGridIncludeTopHeaderAndLeftHeader(lstDoiTuong, lstChiTieu, dataFill, dataUnit, "row", 970);
			$("#btnChuyen").val("Chuyển Menu quay lại");
		} else {
			dataFill = GetDataFoGrid(lstChiTieu, lstDoiTuong);
			BuildGridIncludeTopHeaderAndLeftHeader(lstChiTieu, lstDoiTuong, dataFill, dataUnit, "column", 970);
			$("#btnChuyen").val("Chuyển Menu");
		}
	});

	$("#btnCallMethod").click(function () {
		var data = $("#log_Changes").val();
		var value = { jsonData: data };
		$.ajax({
			url: '/Grid/UpdateData',
			type: 'POST',
			dataType: 'text',
			contentType: 'application/json; charset=utf-8',
			data: JSON.stringify(value),
			success: function (result) {
				$("#log_Changes").val("");
				alert(result);
			},
			error: function () {
				alert('error');
			}
		});
	});

	$("#cbxNhomChiTieu").change(function () {
		$("#example1").empty();
		lstDoiTuong = GetListDoiTuong();
		Nhom_Id = { Nhom_Id: $("#cbxNhomChiTieu").val() };
		lstChiTieu = GetDataCallMethordWithAjax("/Grid/GetListChiTieu", Nhom_Id);
		var dataInputLstChiTieu = { lstChiTieu: JSON.stringify(lstChiTieu) };
		var dataUnit = GetDataCallMethordWithAjax("/Grid/GetUnitFollowListChiTieu", dataInputLstChiTieu);
		dataFill = GetDataFoGrid(lstChiTieu, lstDoiTuong);
		
		BuildGridIncludeTopHeaderAndLeftHeader(lstChiTieu, lstDoiTuong, dataFill, dataUnit, "column", 970);
	});
});

function GetDataCallMethordWithAjax(url, data) {
	var result;
	if(data == null) {
		result = $.ajax({
			url: url,
			type: 'POST',
			dataType: 'json',
			contentType: 'application/json; charset=utf-8',
			async: false
		}).responseText;
	}else {
		result = $.ajax({
			url: url,
			type: 'POST',
			dataType: 'text',
			contentType: 'application/json; charset=utf-8',
			data: JSON.stringify(data),
			async: false
		}).responseText;
	}
	var jsonObject = JSON.parse(result);
	return jsonObject;
}

function GetListDoiTuong() {
	var result = $.ajax({
		url: '/Grid/GetListDoiTuong',
		type: 'POST',
		dataType: 'json',
		contentType: 'application/json; charset=utf-8',
		async: false
	}).responseText;
	var jsonObject = JSON.parse(result);
	return jsonObject;
}

function GetListChiTieu() {
	var result = $.ajax({
		url: '/Grid/GetListChiTieu',
		type: 'POST',
		dataType: 'json',
		contentType: 'application/json; charset=utf-8',
		async: false
	}).responseText;
	var jsonObject = JSON.parse(result);
	return jsonObject;
}

function GetDataFoGrid(lstChiTieu, lstDoiTuong) {
	var value = { lstChiTieu_Id: JSON.stringify(lstChiTieu), lstDoiTuong_Id: JSON.stringify(lstDoiTuong) };
	var result = $.ajax({
		url: '/Grid/GetListThongKe',
		type: 'POST',
		dataType: 'text',
		contentType: 'application/json; charset=utf-8',
		data: JSON.stringify(value),
		async: false
	}).responseText;
	var jsonObject = JSON.parse(result);
	return jsonObject;
}

var tableToExcel = (function() {
	var uri = 'data:application/vnd.ms-excel;base64,', template = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body><table>{table}</table></body></html>', base64 = function(s) { return window.btoa(unescape(encodeURIComponent(s))); }, format = function(s, c) { return s.replace(/{(\w+)}/g, function(m, p) { return c[p]; }); };
	return function(table, name) {
		if (!table.nodeType) table = document.getElementById(table);
		var ctx = { worksheet: name || 'Worksheet', table: table.innerHTML };
		window.location.href = uri + base64(format(template, ctx));
	};
})();

function fnExcelReport() {
	var tabText = "<table border='2px'><tr bgcolor='#87AFC6'>";
	var textRange; var j = 0;
	tab = document.getElementById('htCore'); // id of table


	for (j = 0 ; j < tab.rows.length ; j++) {
		tabText = tabText + tab.rows[j].innerHTML + "</tr>";
		//tab_text=tab_text+"</tr>";
	}

	tabText = tabText + "</table>";
	var arrTd = tabText.match(/<td[^>]*><\/td>/g);
	arrTd.forEach(function (item) {
		if (item.indexOf("; display: none;") >= 0) {
			tabText = tabText.replace(item, "");
		}
	});
	
	tabText = tabText.replace(/<A[^>]*>|<\/A>/g, "");//remove if u want links in your table
	tabText = tabText.replace(/<img[^>]*>/gi, ""); // remove if u want images in your table
	tabText = tabText.replace(/<input[^>]*>|<\/input>/gi, ""); // reomves input params

	var ua = window.navigator.userAgent;
	var msie = ua.indexOf("MSIE ");

	if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./))      // If Internet Explorer
	{
		txtArea1.document.open("txt/html", "replace");
		txtArea1.document.write(tabText);
		txtArea1.document.close();
		txtArea1.focus();
		sa = txtArea1.document.execCommand("SaveAs", true, "Say Thanks to Sumit.xls");
	} 
	else                 //other browser not tested on IE 11
		sa = window.open('data:application/vnd.ms-excel,' + encodeURIComponent(tabText));
	return (sa);
}