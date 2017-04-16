<?php
  use yii\helpers\Html;
  use yii\bootstrap\ActiveForm;
?>

<div class="container">
	<div class="section white-section">
		<div class="profile-wrapper">
			<div class="row">
				<div class="col-sm-12">
					<h2>Создание перевода в категории «Книги»</h2>
					<br>

					<ul class="nav nav-tabs">
					  <li><a href="/translation/creation">Категория перевода</a></li>
					  <li class="active"><a>Загрузка материалов</a></li>
					  <li class="disabled"><a>Разбиение на фрагменты</a></li>
					</ul>
					<div class="tab-content create-translatioin-tabs">
						<?php $form = ActiveForm::begin(['options' => ['enctype' => 'multipart/form-data']]); ?>
					  <div class="tab-pane fade active in" id="upload">
							
							<div class="row">
								<div class="col-sm-6">
									<div class="upload-translation-info">

										<?= $form->field($model['form'],  'name', [
							            'errorOptions' => [
							                'tag' => 'div',
							                'class' => 'auth-error',
							                ],
							            ])
							        ->label('Название:')
							        ->textInput(['placeholder' => 'PHP. Объекты, шаблоны и методики программирования', 'id' => 'nameInput', 'class' => 'form-control'])
							      ?>

										<?= $form->field($model['form'],  'nameOriginal', [
							            'errorOptions' => [
							                'tag' => 'div',
							                'class' => 'auth-error',
							                ],
							            ])
							        ->label('Оригинальное название:')
							        ->textInput(['placeholder' => 'PHP Objects, Patterns, and Practice', 'id' => 'nameOriginalInput', 'class' => 'form-control'])
							      ?>

										<?= $form->field($model['form'],  'authorName', [
							            'errorOptions' => [
							                'tag' => 'div',
							                'class' => 'auth-error',
							                ],
							            ])
							        ->label('Автор:')
							        ->textInput(['placeholder' => 'Мэт Зандстра', 'id' => 'authorNameInput', 'class' => 'form-control'])
							      ?>

										<?= $form->field($model['form'],  'authorOriginalName', [
							            'errorOptions' => [
							                'tag' => 'div',
							                'class' => 'auth-error',
							                ],
							            ])
							        ->label('Автор (имя на оригинальном языке):')
							        ->textInput(['placeholder' => 'Matt Zandstra', 'id' => 'authorOriginalNameInput', 'class' => 'form-control'])
							      ?>

										<?= $form->field($model['form'],  'year', [
							            'errorOptions' => [
							                'tag' => 'div',
							                'class' => 'auth-error',
							                ],
							            ])
							        ->label('Год издания:')
							        ->textInput(['placeholder' => '2015', 'id' => 'yearInput', 'class' => 'form-control'])
							      ?>

										<?= $form->field($model['form'],  'coverLink', [
							            'errorOptions' => [
							                'tag' => 'div',
							                'class' => 'auth-error',
							                ],
							            ])
							        ->label('Обложка книги (url картинки):')
							        ->textInput(['placeholder' => 'https://images-na.ssl-images-amazon.com/images/I/510IpQcpYXL._UY250_.jpg', 'id' => 'coverLinkInput', 'class' => 'form-control'])
							      ?>

										<?= $form->field($model['form'],  'fromLanguageID', [
							            'errorOptions' => [
							                'tag' => 'div',
							                'class' => 'auth-error',
							                ],
							            ])
							        ->label('Язык оригинала:')
							        ->dropDownList($model['languages'], ['id' => 'fromLanguageIDInput', 
							        	'class' => 'form-control'])
							      ?>

							      <?= $form->field($model['form'],  'toLanguageID', [
							            'errorOptions' => [
							                'tag' => 'div',
							                'class' => 'auth-error',
							                ],
							            ])
							        ->label('Язык перевода:')
							        ->dropDownList(array_reverse($model['languages']), ['id' => 'toLanguageIDInput', 
							        	'class' => 'form-control'])
							      ?>

                    <?= $form->field($model['form'],  'bookFile', [
							            'errorOptions' => [
							                'tag' => 'div',
							                'class' => 'auth-error',
							                ],
							            ])
							        ->label('Выберите файл (поддерживаемые форматы: txt):')
							        ->fileInput();
							      ?>

                    <?= $form->field($model['form'],  'originalText', [
							            'errorOptions' => [
							                'tag' => 'div',
							                'class' => 'auth-error',
							                ],
							            ])
							        ->label('Или скопируйте текст в это поле:')
							        ->textarea(['rows' => '6', 'id' => 'originalTextInput', 
							        	'class' => 'form-control'])
							      ?>

                    <label class="icr-label">
                        <span class="icr-item type_checkbox"></span>
                        <span class="icr-hidden"><input class="icr-input" type="checkbox" name="makePrivate"></span>
                        <span class="icr-text">Сделать перевод приватным</span>
                    </label>


									</div>
								</div>
							</div>
							
							<a class="btn btn-default btn-md" href="/translation/creation">Назад</a>&nbsp;
					    <button type="submit" class="btn btn-success btn-md" href="/translation/creation/fragmentation">Далее</button>
            <?php ActiveForm::end(); ?>
					  </div>
					</div>
				</div>
			</div>
		</div>
	</div>
</div>