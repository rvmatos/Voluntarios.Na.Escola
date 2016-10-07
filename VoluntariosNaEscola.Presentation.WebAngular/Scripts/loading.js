var loadingInterval = [];

var loadings = [];

var loadingIds = 0;

var loadingTimeout = null;

function initLoading() {
    loadingIds++;
    var id = loadingIds;

    $('body').append('<div id="loading-' + id + '"  class="loader-appdatabase"> ' +
    '    <div class="overlay"></div>                    ' +
    '    <div class="bubble-container">                 ' +
    '        <div class="bubble-border">                ' +
    '            <div id="1" class="bubble"></div>      ' +
    '        </div>                                     ' +
    '        <div class="bubble-border">                ' +
    '            <div id="2" class="bubble"></div>      ' +
    '        </div>                                     ' +
    '        <div class="bubble-border">                ' +
    '            <div  id="3" class="bubble"></div>     ' +
    '        </div>                                     ' +
    '        <div class="bubble-border">                ' +
    '            <div  id="4" class="bubble"></div>     ' +
    '        </div>                                     ' +
    '    </div>                                         ' +
    '</div>');

    var obj = { id: id };

    setTimeout(function () {
        deactiveLoading();
    }, 1);

    loadings.push(obj);

    var $loaderSenac = $('#loading-' + id);

    if (loadingInterval != null)
        clearInterval(loadingInterval);

    loadingInterval = setTimeout(function (obj) {
        $loaderSenac.addClass('active');
        animateBubbles(obj);
    }, 300, obj);


    //$('body').css('overflow', 'hidden');

    $loaderSenac.find('.bubble').each(function () {
        $(this).removeClass('active');
    });
};

function deactiveLoading() {
    var length = loadings.length;
    for (var i = 0; i < length - 1 ; i++) {
        var load = loadings[i];
        $('#loading-' + load.id).removeClass('active');
        clearInterval(load.loadingInterval);
    }
}

function hideLoading() {

    if (loadingInterval != null)
        clearInterval(loadingInterval);

    if (loadings.length > 0) {

        try {
            clearInterval(loadings[0].loadingInterval);
        } catch (e) {

        }

        var $loaderSenac = $loaderSenac = $('#loading-' + loadings[0].id);

        loadings.splice(0, 1);

        $loaderSenac.removeClass('active');

        $loaderSenac.find('.bubble').each(function () {
            $(this).removeClass('active');
        });

        setTimeout(function ($loaderSenac) {
            $loaderSenac.remove();
        }, 300, $loaderSenac);
    }
    // $('body').css('overflow', '');
};

function animateBubbles(obj) {

    var $loaderSenac = $('#loading-' + obj.id);

    var bubblesArray = [];
    var $bubbles = $loaderSenac.find('.bubble');
    var length = $bubbles.length;


    for (var i = 0; i < length; i++) {
        bubblesArray.push({
            active: false,
            $bubble: $($bubbles[i])
        });
    }
    bubblesArray[0].active = true;


    obj.loadingInterval = setInterval(function () {
        var obj = getActiveAndNext(bubblesArray);

        obj.$actual.$bubble.removeClass('active');
        obj.$next.$bubble.addClass('active');
    }, 250);
};

function getActiveAndNext($bubbles) {
    var length = $bubbles.length;
    var $actual, $next;

    for (var i = 0; i < length; i++) {
        if ($bubbles[i].active) {
            $actual = $bubbles[i];
            $bubbles[i].active = false;
            if (i == length - 1) {
                $next = $bubbles[0];
                $bubbles[0].active = true;
            }
            else {
                $next = $bubbles[i + 1];
                $bubbles[i + 1].active = true;
            }
            break;
        }
    }

    return {
        $actual: $actual,
        $next: $next
    };
};
