<div class="container">
	<div class="section white-section">
		<div class="profile-wrapper">
			<div class="row">
				<div class="col-sm-12">
					<h2>Создание перевода</h2>
					<br>

					<ul class="nav nav-tabs">
					  <li class="active"><a href="#category" data-toggle="tab">Категория перевода</a></li>
					  <li class="disabled"><a>Загрузка материалов</a></li>
					  <li class="disabled"><a>Разбиение на фрагменты</a></li>
					</ul>
					<div class="tab-content create-translatioin-tabs">
					  <div class="tab-pane fade active in" id="category">
							<form action="/translation/creation/upload" method="GET">
								<div class="choose-trans-category-wrapepr">
							  	<label class="icr-label">
								    <span class="icr-item type_radio"></span>
								    <span class="icr-hidden">
								    	<input class="icr-input" type="radio" checked name="category" value="book" />
								    </span>
								    <span class="icr-text">Книги</span>
									</label>

									<label class="icr-label">
								    <span class="icr-item type_radio"></span>
								    <span class="icr-hidden">
								    	<input class="icr-input" type="radio" disabled name="category" value="0" />
								    </span>
								    <span class="icr-text">Музыка</span>
									</label>

									<label class="icr-label">
								    <span class="icr-item type_radio"></span>
								    <span class="icr-hidden">
								    	<input class="icr-input" type="radio" disabled name="category" value="0" />
								    </span>
								    <span class="icr-text">Видео</span>
									</label>

									<label class="icr-label">
								    <span class="icr-item type_radio"></span>
								    <span class="icr-hidden">
								    	<input class="icr-input" type="radio" disabled name="category" value="0" />
								    </span>
								    <span class="icr-text">Графические материалы</span>
									</label>
								</div>

						    <button class="btn btn-success btn-md" type="submit">Далее</button>
							</form>

					  </div>
					</div>
				</div>
			</div>
		</div>
	</div>
</div>