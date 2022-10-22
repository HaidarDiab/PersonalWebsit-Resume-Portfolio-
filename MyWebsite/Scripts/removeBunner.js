window.addEventListener("load", function () {
	var bannerNode = document.querySelector('[alt="www.somee.com"]').parentNode.parentNode;
	bannerNode.parentNode.removeChild(bannerNode);
});
