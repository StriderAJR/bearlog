<div class="container">
	<div class="section white-section">
		<div class="profile-wrapper">
			<div class="row">
				<div class="col-sm-12">
					<h2>Создание перевода</h2>
					<br>

					<ul class="nav nav-tabs">
					  <li><a href="/translation/creation">Категория перевода</a></li>
					  <li class="active"><a>Загрузка материалов</a></li>
					  <li class="disabled"><a>Разбиение на фрагменты</a></li>
					</ul>
					<div class="tab-content create-translatioin-tabs">
					  <div class="tab-pane fade active in" id="upload">
							
							<div class="row">
								<div class="col-sm-6">
									<div class="upload-translation-info">
										<div class="form-group">
											<label class="control-label">Название:</label>
											<input class="form-control" type="text" placeholder="PHP. Объекты, шаблоны и методики программирования">
										</div>

										<div class="form-group">
											<label class="control-label">Оригинальное название:</label>
											<input class="form-control" type="text" placeholder="PHP Objects, Patterns, and Practice">
										</div>

										<div class="form-group">
											<label class="control-label">Автор:</label>
											<input class="form-control" type="text" placeholder="Мэт Зандстра">
										</div>

										<div class="form-group">
											<label class="control-label">Автор (имя на оригинальном языке):</label>
											<input class="form-control" type="text" placeholder="MattZandstra">
										</div>

										<div class="form-group">
											<label class="control-label">Год издания:</label>
											<input class="form-control" type="text" placeholder="2015">
										</div>

										<div class="form-group">
											<label class="control-label">Обложка книги (url картинки):</label>
											<input class="form-control" type="text" placeholder="https://images-na.ssl-images-amazon.com/images/I/510IpQcpYXL._UY250_.jpg">
										</div>
										
										<div class="form-group">
										 <label class="control-label">Язык оригинала:</label>
										 <select class="form-control">
							          <option>eng</option>
							          <option>ru</option>
							        </select>
										</div>

										<div class="form-group">
										 <label class="control-label">Язык перевода:</label>
										 <select class="form-control">
							          <option>ru</option>
							          <option>eng</option>
							        </select>
										</div>

                    <div class="form-group">
											<label class="control-label">Выберите файл (поддерживаемые форматы: txt, rtf, doc):</label>
											<input class="form-control" type="file">
                    </div>

                    <div class="form-group">
											<label class="control-label">Или скопируйте текст в это поле:</label>
											<textarea class="form-control" rows="3" id="textArea"></textarea>
                    </div>

                    <label class="icr-label">
                        <span class="icr-item type_checkbox"></span>
                        <span class="icr-hidden"><input class="icr-input" type="checkbox" name="hello"></span>
                        <span class="icr-text">Сделать перевод приватным</span>
                    </label>

									</div>
								</div>
							</div>
							
							<a class="btn btn-default btn-md" href="/translation/creation">Назад</a>&nbsp;
					    <a class="btn btn-success btn-md" href="/translation/creation/upload">Далее</a>
					  </div>
					</div>
				</div>
			</div>
		</div>
	</div>
</div>