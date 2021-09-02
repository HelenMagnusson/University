

$.validator.addMethod('streetnr', function (value, element, params) {
    let last = value.split(' ').pop();
    let res = parseInt(last);
    if (isNaN(res)) return false;
    let max = parseInt(params);
    return res <= max
});

$.validator.unobtrusive.adapters.addSingleVal('streetnr', 'max');