function BuildGridIncludeTopHeaderAndLeftHeader(dataLeftHeader, dataTopHeader, dataFill, dataUnit, dataUnitPosition, widthMax) {
	var rowTopStart = 0;
	var colTopStart = GetLevelCase(dataLeftHeader, "0", 0);
	var rowLeftStart = GetLevelCase(dataTopHeader, "0", 0);;
	var colLeftStart = 0;
	var defaultBackground = "#89C4F4";

	//Tạo ra topHeader. (data: dữ liệu topMenu dạng danh sách đối tượng, parentId: Id cha của topMenu, rowStart: số dòng bắt đầu của Grid, colStart: số cột bắt đầu của Grid)
	var dataTop = ConvertTopHeader(dataTopHeader, 0, rowTopStart, colTopStart);
	//Lấy về số cột của topHeader. (topHeader: dữ liệu topMenu, topColStart: số cấp cha con của leftMenu)
	var topCol = GetColumnsTopHeader(dataTop, colTopStart);
	//Tạo style cho cột trên Grid. (data: dữ liệu topMenu)
	var columnDataUnit = dataUnit == null ? 0 : dataUnitPosition == "row" ? 0 : 1;
	var colProperties = GeneratorColumnsOption(dataTop, columnDataUnit);
	//Tạo merger cho topHeader. (data: dữ liệu topMenu)
	var mergeCellsProperties = GeneratorMergeCellsOption(dataTop);
	//Lấy về danh sách ID trên TopHeader. (dataHeader: dữ liệu topMenu, topLevel: số cấp cha con của topMenu, leftLevel: cố cấp cha con của leftMenu)
	var lstCol = GetColIdFollowIdOnGrid(dataTop, rowLeftStart, colTopStart);
    //Tạo ra leftMenu và đổ dữ liệu vào Grid. 
    //(data: Dữ liệu leftMenu dạng danh sách đối tượng, 
    //dataFill: Dữ liệu đổ vào Grid, lstCol: danh sách ID của topMenu, parentId: ID cha của leftMenu, colStart: Cột bắt đầu của leftMenu, 
    //level: 0, topCol: số cột của topMenu, leftLevel: số cấp cha con của LeftMenu, IdTop: Tên của IdTop, IdLeft: Tên của IdLeft, IdGiaTri: Tên của item giá trị)
	var dataLeft = ConvertLeftHeader(dataLeftHeader, dataFill, lstCol, 0, colLeftStart, 0, topCol, colTopStart, "IdTop", "IdLeft", "GiaTri");
	//Tạo dữ liệu đổ vào Grid hoàn chỉnh. (topHeader: dữ liệu topMenu, leftHeader: dữ liệu leftMenu)
	var data = BuildDataFromTopHeaderAndLeftHeader(dataTop, dataLeft);
	//(data: Dữ liệu leftMenu, maxCol: Level của leftMenu)
	var mergeCellsLeftProperties = GeneratorMergeCellsLeftOption(dataLeft, colTopStart, rowLeftStart);
	GeneratorMergerProperties(mergeCellsProperties, mergeCellsLeftProperties);
	//Tạo lại border cho LeftMenu. (data: Dữ liệu LeftMenu, maxCol: Số cột của leftMenu, defaultColor: Màu mặc định của header)
	var borderHeader = SetBorderLeftHeader(dataLeft, rowLeftStart, colTopStart, defaultBackground);
	var widthCol = [];
	if(dataUnit == null) {
		widthCol = BuildWidthColumnsForGrid((topCol + colTopStart), colTopStart, widthMax);
	} else {
		if (dataUnitPosition == "column") {
			AddUnitColumnForGrid(data, dataUnit, rowLeftStart);
			widthCol = BuildWidthColumnsForGrid((topCol + colTopStart + 1), colTopStart, widthMax);
		}
		else {
			AddUnitRowForGrid(data, dataUnit, colTopStart, lstCol);
			widthCol = BuildWidthColumnsForGrid((topCol + colTopStart), colTopStart, widthMax);
		}
	}
	//Tạo style cho Header Top vad Left. (data: DL dạng Handsontable, levelTop: Số cấp cha con của menu Top, levelLeft: Số cấp cha con của menu Left).
	var cellPro = SetCellHeaderProperties(data, rowLeftStart, colTopStart);

	var container = document.getElementById('example1');
	var config = {
		data: data,
		columns: colProperties,
		mergeCells: mergeCellsProperties,
		customBorders: borderHeader,
		cell: cellPro,
		maxRows: data.numberOfRows,
		maxCols: data.numberOfColumns,
		colHeaders: true,
		rowHeaders: true,
		manualColumnResize: true,
		contextMenu: {
			callback: function (key, options) {
				if (key === 'about') {
					setTimeout(function () {
						//timeout is used to make sure the menu collapsed before alert is shown
						alert("This is a context menu with default and custom options mixed");
					}, 100);
				}
			},
			items: {
				"row_above": {
					disabled: function () {
						//if first row, disable this option
						return (hot.getSelected()[0] === 0);
					},
					name: 'Thêm dòng mới ở bên trên'
				},
				"row_below": { name: 'Thêm dòng mới ở bên dưới' },
				"hsep1": "---------",
				"remove_row": {
					name: 'Remove this row, ok?',
					disabled: function () {
						//if first row, disable this option
						return (hot.getSelected()[0] === 0);
					}
				},
				"hsep2": "---------",
				"about": { name: 'About this menu' }
			}
		},
		colWidths: widthCol,
		beforeChange: function (changes, source) {
			for (var i = 0; i < changes.length; i++) {
				if(changes[i][3] != "" && changes[i][2] != changes[i][3]) {
					if(isNaN(changes[i][3])) {
						return false;
					}
					if (dataUnitPosition == "column") {
						var idLeft;
						for (var j = 0; j < data[changes[i][0]].length; j++) {
							if(data[changes[i][0]][j] != "") {
								idLeft = data[changes[i][0]][j].split("|")[1];
								break;
							}
						}
						for (var k = 0; k < dataUnit.length; k++) {
							if(dataUnit[k].Id == idLeft) {
								if (dataUnit[k].Title == "Phần trăm" || dataUnit[k].Value.indexOf("%") >= 0) {
									changes[i][3] = changes[i][3] / 100;
									break;
								}
							}
						}
					}else {
						for (var y = 0; y < dataUnit.length; y++) {
							if (dataUnit[y].Id == lstCol[changes[i][1] - colTopStart].Id) {
								if (dataUnit[y].Title == "Phần trăm" || dataUnit[y].Value.indexOf("%") >= 0) {
									changes[i][3] = changes[i][3] / 100;
									break;
								}
							}
						}
					}
				}
			}
			return true;
		},
		cells: function (row, col, prop) {
			var cellProperties = {};
			if (dataUnit != null) {
				if (dataUnitPosition == "column") {
					if (row >= rowLeftStart && col >= colTopStart) {
						cellProperties.type = "numeric";
						var idLeft;
						for (var i = 0; i < data[row].length; i++) {
							if (data[row][i] != "") {
								idLeft = data[row][i].split("|")[1];
								break;
							}
						}
						for (var j = 0; j < dataUnit.length; j++) {
							if (dataUnit[j].Id == idLeft) {
								cellProperties.format = dataUnit[j].Value;
								break;
							}
						}
						if(col == (data[row].length - 1)) {
							cellProperties.readOnly = true;
						}
					}
				} else {
					if (row >= rowLeftStart && col >= colTopStart) {
						cellProperties.type = "numeric";
						for (var y = 0; y < dataUnit.length; y++) {
							if (dataUnit[y].Id == lstCol[col - colTopStart].Id) {
								cellProperties.format = dataUnit[y].Value;
								break;
							}
						}
						if(row == (data.length - 1)) {
							cellProperties.readOnly = true;
						}
					}
				}
			}
			return cellProperties;
		}
	};
	
	var hooks = Handsontable.hooks.getRegistered();
	hooks.forEach(function (hook) {
		if (hook == 'afterChange') {
			config[hook] = function () {
				logEvents(hook, arguments);
			};
		}
	});

	var hot = new Handsontable(container, config);

	//Lưu lại lịch sử thay đổi để biến nó thành một danh sách các đối tượng được thay đổi. Phục vụ cho quá trình lưu dữ liệu được dễ dàng hơn.
	function logEvents(event, dataEvent) {
		if (event == 'afterChange') {
			if (dataEvent != null && dataEvent[0] != null) {
				for (var index = 0; index < dataEvent[0].length; index++) {
					if (dataEvent[0][index] != null && dataEvent[0][index].length == 4) {
						if (dataEvent[0][index][2] != dataEvent[0][index][3]) {
							var idRow = GetIdRowOnGrid(data, dataEvent[0][index][0]);
							var idCol = GetIdColOnGrid(data, dataEvent[0][index][1], rowLeftStart);
							var dataChange = $("#log_Changes").val();
							if (dataChange == null || dataChange == "") {
								dataChange = '{"IdRow":"' + idRow + '", "IdCol":"' + idCol + '", "ValueOld":"' + dataEvent[0][index][2] + '", "Value":"' + dataEvent[0][index][3] + '"}';
								$("#log_Changes").val(dataChange);
							} else {
								var jsonObjectChange = JSON.parse("[" + dataChange + "]");
								var exist = false;
								for (var i = 0; i < jsonObjectChange.length; i++) {
									if (jsonObjectChange[i].IdRow == idRow && jsonObjectChange[i].IdCol == idCol) {
										exist = true;
										var itemTemp = '{"IdRow":"' + idRow + '", "IdCol":"' + idCol + '", "ValueOld":"' + jsonObjectChange[i].ValueOld + '", "Value":"' + jsonObjectChange[i].Value + '"}';
										if (jsonObjectChange[i].ValueOld == dataEvent[0][index][3]) {
											dataChange = dataChange.replace(itemTemp, "").replace(",,", ",");
											if (dataChange.indexOf(",") == 0) {
												dataChange = dataChange.substring(1);
											}
										} else {
											var itemNew = '{"IdRow":"' + idRow + '", "IdCol":"' + idCol + '", "ValueOld":"' + jsonObjectChange[i].ValueOld + '", "Value":"' + dataEvent[0][index][3] + '"}';
											dataChange = dataChange.replace(itemTemp, itemNew);
										}
										break;
									}
								}
								if (!exist) {
									dataChange += ',{"IdRow":"' + idRow + '", "IdCol":"' + idCol + '", "ValueOld":"' + dataEvent[0][index][2] + '", "Value":"' + dataEvent[0][index][3] + '"}';
								}
								$("#log_Changes").val(dataChange);
							}
						}
					}
				}
			}
		}
	}
}

function AddUnitColumnForGrid(data, dataUnit, levelTop) {
	for (var i = 0; i < data.length; i++) {
		if(i < levelTop) {
			if(i == 0) {
				data[i].push("ĐVT");
			}else {
				data[i].push("");
			}
		}else {
			var idLeft = 0;
			for (var k = 0; k < data[i].length; k++) {
				if(data[i][k] != "") {
					idLeft = data[i][k].split("|")[1];
					break;
				}
			}
			for (var j = 0; j < dataUnit.length; j++) {
				if(dataUnit[j].Id == idLeft) {
					data[i].push(dataUnit[j].Title);
					break;
				}
			}
		}
	}
}

function AddUnitRowForGrid(data, dataUnit, levelLeft, lstIdTop) {
	if(data != null && data.length > 0) {
		var totalCol = data[0].length;
		if (totalCol > 0) {
			var item = [];
			for (var i = 0; i < totalCol; i++) {
				if(i == 0) {
					item.push("Đơn vị tính");
				}else if(i < levelLeft) {
					item.push("");
				}else {
					for (var j = 0; j < dataUnit.length; j++) {
						if(dataUnit[j].Id == lstIdTop[i - levelLeft].Id) {
							item.push(dataUnit[j].Title);
							break;
						}
					}
				}
			}
			data.push(item);
		}
	}
}

function BuildWidthColumnsForGrid(totalCol, levelLeftMenu, widthMax) {
	if (totalCol == 0)
		return [];
	var result = [];
	var widthItem;
	var total;
	var surplus;
	if(levelLeftMenu == 1) {
		result.push(200);
		widthItem = Math.round((widthMax - 200) / (totalCol - 1));
		for (var j = 1; j < totalCol; j++) {
			result.push(widthItem);
		}
		total = 0;
		$.each(result, function () {
			total += this;
		});
		surplus = widthMax - total;
		result[0] = result[0] + surplus;
	}
	else {
		var colHeaderLast = levelLeftMenu - 1;
		widthItem = 50;
		for (var i = 0; i < totalCol; i++) {
			if (i == colHeaderLast) {
				result.push(150);
				total = 0;
				$.each(result, function () {
					total += this;
				});
				widthItem = Math.round((widthMax - total) / (totalCol - levelLeftMenu));
			} else if (i < colHeaderLast) {
				result.push(20);
			}else {
				result.push(widthItem);
			}
		}
		total = 0;
		$.each(result, function () {
			total += this;
		});
		surplus = widthMax - total;
		result[colHeaderLast] = result[colHeaderLast] + surplus;
	}
	return result;
}

//Lấy về danh sách ID cột
function GetColIdFollowIdOnGrid(dataHeader, topLevel, leftLevel){
	var result = [];
	if(dataHeader.length > 0) {
		for (var i = leftLevel; i < dataHeader[0].length; i++) {
			for (var j = (topLevel - 1) ; j >= 0; j--) {
				if (dataHeader[j][i] != "") {
				    result.push({ col: i, Id: parseInt(dataHeader[j][i].split('|')[1]) });
					break;
				}
			}
		}
	}
	return result;
}

//Lấy về ID của top khi có vị trí của cột
function GetIdColOnGrid(dataHeader, colIndex, colLevel){
	if(dataHeader == null || dataHeader.length <= colLevel){
		return null;}
	for(var i = (colLevel - 1); i >= 0; i--){
		if(dataHeader[i][colIndex] != ""){
			return dataHeader[i][colIndex].split('|')[1];
		}
	}
	return null;
}

//Lấy về ID của row trên Grid khi có vị trí của hàng
function GetIdRowOnGrid(dataHeader, rowIndex){
	if(dataHeader == null || dataHeader.length <= rowIndex){
		return null;}
	for(var i = 0; i < dataHeader[rowIndex].length; i++){
		if(dataHeader[rowIndex][i] != ""){
			return dataHeader[rowIndex][i].split('|')[1];
		}
	}
	return null;
}

//Tạo style cho header top và left
function SetCellHeaderProperties(data, levelTop, levelLeft){
	var result = SetCellTopHeaderProperties(data, levelTop);
	SetCellLeftHeaderProperties(data, levelLeft, result);
	return result;
}

//Tạo style cho header left 
function SetCellLeftHeaderProperties(data, level, cellProperties){
	if(data.length <= 0 || level == 0){
		return cellProperties;
	}
	for(var i = 0; i < data.length; i++){
		for(var j = 0; j < level; j++){
			cellProperties.push({row: i, col: j, className: "htLeft", readOnly: true, renderer: headerRowRenderer});
		}
	}
	return cellProperties;
}

// Tạo style cho top header
function SetCellTopHeaderProperties(data, level){
	var cellProperties = [];
	if(data.length <= 0 || level == 0){
		return cellProperties;
	}
	for(var i = 0; i < data[0].length; i++){
		for(var j = 0; j < level; j++){
			cellProperties.push({row: j, col: i, className: "htCenter", readOnly: true, renderer: headerRowRenderer});
		}
	}
	return cellProperties;
}

//Style header
function headerRowRenderer(instance, td, row, col, prop, value, cellProperties){	
	Handsontable.renderers.HtmlRenderer.apply(this, arguments);
    td.style.fontWeight = 'bold';
    td.style.color = '#000000';
    td.style.background = "#89C4F4";
}

//Tạo border cho left header
function SetBorderLeftHeader(data, startRow, maxCol, defaultColor){
	var result = [];
	SetBorderTopLeftHeader(data, startRow, maxCol, result);
	SetBorderBottomLeftHeader(data, startRow, result, defaultColor);
	return result;
}

//Tạo border top cho left header
function SetBorderTopLeftHeader(data, startRow, maxCol, borderLeftHeader) {
	for(var i = 0; i < data.length; i++){
		for(var j = 0; j < maxCol; j++){
			if(data[i][j] != ""){
				var item = { row: (i + startRow), col: j, top: { color: 'lightgray' } };
				borderLeftHeader.push(item);
				break;
			}
		}
	}
}

//Tạo border bottom cho left header
function SetBorderBottomLeftHeader(data, startRow, borderLeftHeader, defaultColor) {
	for(var i = 0; i < data.length - 1; i++){
		if(data[i][0] == ""){
			var item = { row: (i + startRow), col: 0, bottom: { color: defaultColor } };
			borderLeftHeader.push(item);
		}
	}
}

//Gộp merge cell left vào merge cell top
function GeneratorMergerProperties(mergeTop, mergeLeft){
	for(var i = 0; i < mergeLeft.length; i++){
		mergeTop.push(mergeLeft[i]);		
	}
}

//Tạo ra mảng merge cell left header
function GeneratorMergeCellsLeftOption(data, maxCol, levelTop){
	var result = [];
	var row = data.length;
	if(row <= 0){
		return result;
	}
	var col = data[0].length;
	if(col <= 0 || col <= maxCol){
		return result;
	}
	for(var i = 0; i < data.length; i++){
		for(var j = 0; j < maxCol; j++){
			if((j == 0) || data[i][j] != "") {
				var item = CreateItemLeftMerger(data, i, j, maxCol, levelTop);
				if(item != null){
					result.push(item);
				}
			}
		}
	}
	return result;
}

//Tạo từng item cho mảng merge cell left header
function CreateItemLeftMerger(data, row, col, maxCol, levelTop){
	var colSpan = 1;
	for(var i = (col + 1); i < maxCol; i++){
		if(data[row][i] != ""){
			break;
		}
		colSpan++;
	}
	if(colSpan == 1){
		return null;
	}
	return { row: (row + levelTop), col: col, rowspan: 1, colspan: colSpan };
}

//Gộp left header vào top header
function BuildDataFromTopHeaderAndLeftHeader(topHeader, leftHeader){
	if(leftHeader.length > 0){
		for(var i = 0; i < leftHeader.length; i++){
			topHeader.push(leftHeader[i]);
		}
	}
	return topHeader;
}

//Tạo ra left header
function ConvertLeftHeader(data, dataFill, lstCol, parentId, colStart, level, topCol, leftLevel, idTop, idLeft, idGiaTri){
	var result = [];
	for(var i = 0; i < data.length; i++){
		if(data[i].ParentId == parentId)
		{
			var item = [];
			for(var j = 0; j < (colStart + topCol + leftLevel); j++){
				if(j == level){
					var value = data[i].Title + "<div id='|" + data[i].Id + "|' style='display: none;'></div>";
					item.push(value);
				}
				else{
					var added = false;
					if(j >= leftLevel){
						var idItemTop = lstCol[j - leftLevel].Id;						
						for(var x = 0; x < dataFill.length;x++){
							if(dataFill[x][idTop] === idItemTop && dataFill[x][idLeft] === data[i].Id){
							    item.push( dataFill[x][idGiaTri]) ;
								added = true;
								break;
							}
						}
					}
					if(!added){
						item.push("");
					}
				}
			}
			result.push(item);
			var listItems = ConvertLeftHeader(data, dataFill, lstCol, data[i].Id, colStart, level + 1, topCol, leftLevel, idTop, idLeft, idGiaTri);
			if(listItems.length > 0){
				for(var j = 0; j < listItems.length; j++){
					result.push(listItems[j]);
				}
			}
		}
	}
	return result;
}

//Lấy về số cột mà topHeader sử dụng
function GetColumnsTopHeader(topHeader, topColStart) {
	if (topHeader.length > 0)
		return (topHeader[0].length - topColStart);
	return 0;
}

//Lấy về tổng số cấp cha con
function GetLevelCase(data, parentId, level){
	var totalLevel = level;
	var childLevel;
	for(var i =0; i < data.length; i++){
		childLevel = level;
		if (data[i].ParentId == parentId) {
			childLevel++;
			childLevel = GetLevelCase(data, data[i].Id, childLevel);	
			if(childLevel > totalLevel){
				totalLevel = childLevel;
			}
		}
	}
	return totalLevel;
}

//Tạo ra mảng merge cell top header
function GeneratorMergeCellsOption(data){
	var result = [];
	var row = data.length;
	if(row <= 0){
		return result;
	}
	var col = data[0].length;
	if(col <= 0){
		return result;
	}
	for(var i = 0; i < row; i++){
		for(var j = 0; j < col; j++){
			if((i ==0 && j == 0) || data[i][j] != "") {
				var item = GeneratorItemColumnOption(data, i, j, row, col, result);	
				if(item != null && item.length != 0)
				{
					result.push(item);
				}
			}
		}
	}
	return result;
}

//Tạo ra từng item cho mảng merge cell top header
function GeneratorItemColumnOption(data, row, col, maxRow, maxCol, mergeData){
	var rowSpan = 1;
	var colSpan = 1;
	for(var i = (col + 1); i < maxCol; i++){
		if(data[row][i] != "")
		{
			break;
		}
		if(mergeData.length > 0){
			var existItem = false;
			for(var j = 0; j< mergeData.length; j++){
				if(mergeData[j].row <= row && (row + rowSpan) <= (mergeData[j].row + mergeData[j].rowspan)){
					var tempCol = col + colSpan;
					if(mergeData[j].col <= tempCol && tempCol <= mergeData[j].col + mergeData[j].colspan){
						existItem = true;
					}
				}
			}
			if(!existItem){
				colSpan++;
			}
		}else{
			colSpan++;
		}
	}
	for(var i = (row + 1); i < maxRow; i++){
		if(data[i][col] != "")
		{
			break;
		}
		rowSpan++;
	}
	if(colSpan == 1 && rowSpan == 1){
		return null;
	}
	return {row: row, col: col, rowspan: rowSpan, colspan: colSpan};
}

//Tạo ra loại dữ liệu cho columns
function GeneratorColumnsOption(data, columnUnit){
	var result = [];
	if(data.length <= 0){
		return result;
	}
    var maxColumn = data[0].length;
    for (var i = 0; i < maxColumn + columnUnit; i++) {
    	var item = { data: "" + i, className: "htRight"};
        result.push(item);
    }
	if(columnUnit > 0) {
		result[(maxColumn + columnUnit - 1)].className = "htLeft";
	}
	return result;
}

//Lấy về số cột của top header
function MaxColumnJson(data){
    var maxColumn = 0;
	for(var i = 0; i < data.length; i++){
		if(i == 0){
			maxColumn = data[i].Columns;
		}else{
			if(data[i].row == data[0].row){
				maxColumn = maxColumn + data[i].Columns;
			}
		}
	}
    return maxColumn;
}

//Tạo ra top header
function ConvertTopHeader(data, parentId, rowStart, colStart){
    var dataObject = ConvertToHeader(data, parentId, rowStart, colStart);
    return ConvertToHeaderFromObjectToJson(dataObject, rowStart, colStart);
}

//Chuyển từ một đối tượng được định nghĩa sang kiểu data handsontable
function ConvertToHeaderFromObjectToJson(data, rowStart, colStart){
    data.sort(function (a, b) {
        if (a.row > b.row) {
            return 1;
          }
          if (a.row < b.row) {
            return -1;
          }
          return 0;
    });
	var maxColumn = MaxColumnJson(data);
    var tempData = [];
    for(var i = 0; i < data.length; i++){
        var exist = false;
        if(tempData.length != 0){
            if(data[i].row <= (rowStart + tempData.length - 1))
            {
                exist = true;
                var index = data[i].row - rowStart;
                var value = data[i].Title + "<div id='|" + data[i].Id + "|' style='display: none;'></div>";
				tempData[index].splice(data[i].col, 1, value);
            }
        }
        if(!exist)
        {
			var value = [];
            for(var j = 0; j < (maxColumn + colStart); j ++){
                if(j == data[i].col){
                    var itemValue = data[i].Title + "<div id='|" + data[i].Id + "|' style='display: none;'></div>";
                    value.push(itemValue);
                }else{
                    value.push("");
                }
            }
			tempData.push(value);
        }
    }
	return tempData;
}

//Chuyển từ một đối tượng gồm ID, Title, ParentId sang một object được định nghĩa
function ConvertToHeader(headerData, parentId, row, col){    
    var tempData = [];
    var column = col;
    for(var i = 0; i < headerData.length; i++){
        if(headerData[i].ParentId == parentId){
            var columns = GetColumnsHeaderParentAndChild(headerData, headerData[i].Id, 1);
            var objectTemp = {
                Id: headerData[i].Id, 
                Title: headerData[i].Title, 
                Columns: columns,
                row: row,
                col: column
            };
            tempData.push(objectTemp);
            var tempChild = ConvertToHeader(headerData, headerData[i].Id, (row + 1), column);
            if(tempChild != null && tempChild.length > 0)
            {
                for(var j = 0; j < tempChild.length; j++){
                    tempData.push(tempChild[j]);
                }
            }
            column = columns + column;
        }
    }
    return tempData;
}

//Trả về số cột tối đa cho nó và con cháu của nó
function GetColumnsHeaderParentAndChild(data, parentId, columns){
    var totalColumns = columns;
    var tempData = [];
    for(var i = 0; i < data.length; i++){
        if(data[i].ParentId == parentId){
            tempData.push(data[i]);
            totalColumns = GetColumnsHeaderParentAndChild(data, data[i].Id, totalColumns);
        }
    }
    if(tempData.length > 1){
        totalColumns = totalColumns + tempData.length - 1;
    }
    return totalColumns;
}

