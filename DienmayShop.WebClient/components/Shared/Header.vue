<template>
	<header class="section-header border-bottom">
		<nav class="navbar navbar-expand-xl navbar-light">
			<div class="container">
				<a class="navbar-brand" href="/">
					<img src="~/static/images/logo.svg" height="40" class="logo" alt="logo">
				</a>
				<div class="d-flex align-items-center">
					<div class="d-xl-none me-2">
						<a href="" class="btn btn-light"> <i class="fa fa-user"></i> </a>
						<a href="" class="btn btn-light"> <i class="fa fa-heart"></i> </a>
						<a href="" class="btn btn-light"> Cart (2)</a>
					</div>
					<button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbar_main"
						aria-expanded="false" aria-label="Toggle navigation">
						<span class="navbar-toggler-icon"></span>
					</button>
				</div>
				<div class="collapse navbar-collapse" id="navbar_main">
					<ul class="navbar-nav me-auto">
						<li class="nav-item">
							<a class="nav-link" href="#">Home </a>
						</li>
						<li class="nav-item">
							<a class="nav-link" href="#">Men</a>
						</li>
						<li class="nav-item">
							<a class="nav-link" href="#">Women</a>
						</li>
						<li class="nav-item">
							<a class="nav-link" href="#">Kids</a>
						</li>
						<li class="nav-item">
							<a class="nav-link" href="#">Accessory</a>
						</li>
						<li class="nav-item dropdown">
							<a class="dropdown-toggle nav-link" href="#" type="button" data-bs-toggle="dropdown">
								More
							</a>
							<ul class="dropdown-menu">
								<li> <a class="dropdown-item" href="#">Foods and Drink</a> </li>
								<li> <a class="dropdown-item" href="#">Home interior</a> </li>
								<li>
									<hr class="dropdown-divider">
								</li>
								<li> <a class="dropdown-item" href="#">Category name</a> </li>
								<li> <a class="dropdown-item" href="#">Another category</a> </li>
							</ul>
						</li>
					</ul>
					<form class="me-3">
						<div class="input-group">
							<input type="text" class="form-control" placeholder="Search">
							<button class="btn-icon btn-light btn"> <i class="fa fa-search"></i> </button>
						</div>
					</form>
					<div class="widgets-wrap d-none d-xl-flex">
						<div class="widget-header ms-2">
							<a href="/user" class="icon icon-sm rounded-circle bg-gray-200">
								<i class="fa fa-user"></i>
							</a>
						</div>
						<div class="widget-header ms-2">
							<a href="#" class="icon icon-sm rounded-circle bg-gray-200">
								<i class="fa fa-heart"></i>
							</a>
						</div>

						<div class="widget-header  ms-2">
							<a href="/cart" class="icon icon-sm rounded-circle bg-gray-200">
								<i class="fa fa-shopping-cart"></i>
								<span class="notify">2</span>
							</a>
						</div>
					</div>
				</div>
			</div>
		</nav>

	</header>
</template>
<script>
export default {

}
</script>