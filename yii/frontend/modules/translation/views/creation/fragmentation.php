<div class="container">
	<div class="section white-section">
		<div class="profile-wrapper">
			<div class="row">
				<div class="col-sm-12">
					<h2>Разбиение на фрагменты</h2>
					<br>

					<ul class="nav nav-tabs">
					  <li><a href="/translation/creation">Категория перевода</a></li>
					  <li><a href="/translation/creation/upload">Загрузка материалов</a></li>
					  <li class="active"><a>Разбиение на фрагменты</a></li>
					</ul>
					<div class="tab-content create-translatioin-tabs">
					  <div class="tab-pane fade active in" id="fragmentation">
							Данные о переводе:
							<div><b>name</b> <?= $model['translation']->name?></div>
					        <div><b>name_original</b> <?= $model['translation']->name_original?></div>
					        <div><b>from_language_id</b> <?= $model['translation']->from_language_id?></div>
					        <div><b>to_language_id</b> <?= $model['translation']->to_language_id?></div>
					        <div><b>cover_link</b> <?= $model['translation']->cover_link?></div>
					        <div><b>is_private</b> <?= $model['translation']->is_private?></div>
					        <div><b>is_finished</b> <?= $model['translation']->is_finished?></div>
					        <div><b>category_id</b> <?= $model['translation']->category_id?></div>
					        <div><b>creator_id</b> <?= $model['translation']->creator_id?></div>
							<br>
							<br>

					        <div><b>translation_id</b> <?=$model['book']->translation_id?></div>
					        <div><b>author_name</b> <?=$model['book']->author_name?></div>
					        <div><b>author_original_name</b> <?=$model['book']->author_original_name?></div>
					        <div><b>year</b> <?=$model['book']->year?></div>

					        <br>
							<div class="choose-trans-fragmentation-wrapepr">
						  	<label class="icr-label">
								    <span class="icr-item type_radio"></span>
								    <span class="icr-hidden">
								    	<input class="icr-input" type="radio" checked name="category" value="0" />
								    </span>
								    <span class="icr-text">Разбиение по предложениям (Автоматически)</span>
								</label>

								<label class="icr-label">
								    <span class="icr-item type_radio"></span>
								    <span class="icr-hidden">
								    	<input class="icr-input" type="radio" name="category" value="0" />
								    </span>
								    <span class="icr-text">Разбиение по абзацам (Автоматически)  </span>
								</label>

								<label class="icr-label">
								    <span class="icr-item type_radio"></span>
								    <span class="icr-hidden">
								    	<input class="icr-input" type="radio" name="category" value="0" />
								    </span>
								    <span class="icr-text">Произвольное разбиение (Вручную)  </span>
								</label>

								<div class="form-group ">
									<label class="control-label">Пожалуйста, кликните курсором в необходимом месте текста для создания разбиения:</label>
									<textarea class="form-control fragmentation-textarea" rows="40" id="textArea"><?= $model['originalText'] ?></textarea>
                </div>
							</div>

					    <a class="btn btn-default btn-md" href="/translation/creation/upload">Назад</a>&nbsp;
					    <a class="btn btn-success btn-md" href="/translation/creation/check">Далее</a>
					  </div>
					</div>
				</div>
			</div>
		</div>
	</div>
</div>